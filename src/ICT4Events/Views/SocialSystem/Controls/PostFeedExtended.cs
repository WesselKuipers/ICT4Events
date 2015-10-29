using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using ICT4Events.Views.SocialSystem.Forms;
using SharedModels.Data.OracleContexts;
using SharedModels.FTP;
using SharedModels.Logic;
using SharedModels.Models;

namespace ICT4Events.Views.SocialSystem.Controls
{
    public partial class PostFeedExtended : UserControl
    {
        private readonly Post _post;
        private readonly Event _event;
        private readonly Guest _guest;
        private readonly Guest _activeUser;
        private Media _media;
        private readonly MediaOracleContext _logicMedia;
        private readonly PostLogic _logicPost;
        private readonly ReportOracleContext _logicReport;

        public PostFeedExtended(Post post, Event ev, Guest active)
        {
            InitializeComponent();
            _logicMedia = new MediaOracleContext();
            _logicPost = new PostLogic();
            var logicGuest = new GuestLogic(new GuestOracleContext());
            _logicReport = new ReportOracleContext();

            _post = post;
            _event = ev;
            // CURRENT "GUEST" SIGNED IN.
            _activeUser = active;
            // GUEST OF THE POST
            _guest = logicGuest.GetGuestByEvent(_event, _post.GuestID);
        }

        private void PostFeedExtended_Load(object sender, EventArgs e)
        {
            RefreshSocialSystem();

            List<Reply> allReply = _logicPost.GetRepliesByPost(_post);
            int i = 0;
            foreach (Reply p in allReply)
            {
                if (p.MainPostID == _post.ID)
                {
                    if (i <= 5)
                    {
                        tbPanelReplies.RowCount += 1;
                        tbPanelReplies.Controls.Add(new PostFeed(p, _event, _activeUser), 0, i);
                        i++;
                    }
                }
            }
        }

        private void lblDownloadMedia_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (_post.MediaID != 0)
            {
                _media = _logicMedia.GetById(_post.MediaID);
                string dirDownloadedFiles = Path.GetDirectoryName(Application.ExecutablePath) + @"\downloaded_files\";
                string localFilePath = dirDownloadedFiles + _media.Path;

                FolderBrowserDialog saveMedia = new FolderBrowserDialog();

                if (saveMedia.ShowDialog() == DialogResult.OK)
                {
                    string pathSelected = saveMedia.SelectedPath;
                    File.Copy(localFilePath, pathSelected);
                    MessageBox.Show(@"Bestand is succesvol gedownload");
                }
            }
        }

        private void lbReport_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void lbLike_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            _logicPost.Like(_activeUser, _post);
            RefreshSocialSystem();
        }
        private void lblUnLike_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            _logicPost.UnLike(_activeUser, _post);
            RefreshSocialSystem();
        }

        private void lblDeletePost_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (_logicPost.DeletePost(_post))
                MessageBox.Show(@"Post succesvol verwijderd");
            else
                MessageBox.Show(@"Er is iets mis gegaan");
        }

        private void RefreshSocialSystem()
        {
            List<Report> reports = _logicReport.GetAllByPost(_post);
            List<int> likes = _logicPost.GetAllLikes(_post);
            lbLike.Visible = true;
            lblUnLike.Visible = false;

            if (_post.GuestID == _activeUser.ID)
            {
                lbReport.Visible = false;
                lblDeletePost.Visible = true;
            }
            if (reports != null)
            {
                foreach (Report r in reports)
                {
                    if (r.GuestID == _activeUser.ID)
                        lbReport.Enabled = false;
                }
            }
            if (likes != null)
            {
                foreach (int i in likes)
                {
                    if (i == _activeUser.ID)
                    {
                        lbLike.Visible = false;
                        lblUnLike.Visible = true;
                    }
                }
                lblCountLikes.Text = likes.Count + @" mens(en) vinden dit leuk";
            }
            else
            {
                lblCountLikes.Text = @"0 mens(en) vinden dit leuk";
            }
            lbReport1.Text = _post.Content;
            lblAuteurNaam.Text = _guest.Name + @" " + _guest.Surname;
            lblDatum.Text = @"Geplaatst op " + _post.Date.ToString("dd/MM/yyyy");

            #region LoadMedia
            // TODO: User local afsplitsen
            if (_post.MediaID != 0)
            {
                _media = _logicMedia.GetById(_post.MediaID);
                string dirDownloadedFiles = Path.GetDirectoryName(Application.ExecutablePath) + @"\downloaded_files\";
                string ftpPath = @"/" + _post.EventID + @"/" + _post.GuestID + @"/" + _media.Path;
                string localFilePath = dirDownloadedFiles + _media.Path;

                if (!File.Exists(dirDownloadedFiles)) Directory.CreateDirectory(dirDownloadedFiles);

                if (!File.Exists(localFilePath))
                {
                    if (FtpHelper.DownloadFile(ftpPath, localFilePath))
                    {
                        pbMediaMessage.ImageLocation = @localFilePath;
                        pbMediaMessage.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                }
                else
                {
                    pbMediaMessage.ImageLocation = @localFilePath;
                    pbMediaMessage.SizeMode = PictureBoxSizeMode.StretchImage;
                }

            }
            else
            {
                pbMediaMessage.Visible = false;
                lblDownloadMedia.Visible = false;
            }
            #endregion 
        }

        private void btReply_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbReplyMessage.Text))
            {
                string mess = tbReplyMessage.Text;
                AddReply(mess);
            }
            else
            {
                MessageBox.Show(@"Bericht is verplicht!");
            }
        }

        /// <summary>
        /// Reactie methode om een reactie toe te voegen
        /// </summary>
        /// <param name="message"></param>
        private void AddReply(string message)
        {
            Reply r = new Reply(0, _activeUser.ID, _event.ID, 0, _post.ID, DateTime.Now, true, message);
            if (_logicPost.InsertPost(r) != null)
                MessageBox.Show(@"Uw reactie is succesvol toegevoegd");
            else
                MessageBox.Show(@"Er is iets misgegaan");
            RefreshSocialSystem();
        }
    }
}
