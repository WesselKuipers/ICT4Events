using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using ICT4Events.Views.SocialSystem.Forms;
using SharedModels.Data.OracleContexts;
using SharedModels.Enums;
using SharedModels.FTP;
using SharedModels.Logic;
using SharedModels.Models;

namespace ICT4Events.Views.SocialSystem.Controls
{
    public partial class PostFeed : UserControl
    {
        private readonly Post _post;
        private readonly Event _event;
        private readonly Guest _guestPost;
        private readonly User _admin;
        private readonly Guest _activeUser;
        private Media _media;
        private readonly MediaOracleContext _logicMedia;
        private readonly PostLogic _logicPost;
        private readonly GuestLogic _logicGuest;
        private readonly ReportOracleContext _logicReport;
        private PostFeedExtended extended;

        public PostFeed(Post post, Event ev, Guest active, bool reply)
        {
            InitializeComponent();
            _logicMedia = new MediaOracleContext();
            _logicPost = new PostLogic();
            _logicGuest = new GuestLogic(new GuestOracleContext());
            _logicReport = new ReportOracleContext();

            _post = post;
            _event = ev;
            // CURRENT "GUEST" SIGNED IN.
            _activeUser = active;
            // GUEST OF THE POST
            _guestPost = _logicGuest.GetGuestByEvent(_event, _post.GuestID);

            if (reply)
            {
                lbReaction.Visible = false;
            }
        }
        public PostFeed(Post post, Event ev, User admin, bool reply)
        {
            InitializeComponent();
            _logicMedia = new MediaOracleContext();
            _logicPost = new PostLogic();
            _logicGuest = new GuestLogic(new GuestOracleContext());
            _logicReport = new ReportOracleContext();

            _post = post;
            _event = ev;
            // CURRENT "ADMIN" SIGNED IN.
            _admin = admin;
            // GUEST OF THE POST
            _guestPost = _logicGuest.GetGuestByEvent(_event, _post.GuestID);

            if (reply)
            {
                lbReaction.Visible = false;
            }
        }

        private void PostFeed_Load(object sender, EventArgs e)
        {
            RefreshSocialSystem();
        }

        private void lblDownloadMedia_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DownloadMedia(_post);
        }
        private void lbReport_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (CheckReportStatus(_post, _logicPost, _logicReport))
            {
                MessageBox.Show($"Bericht is verborgen. Je kunt geen rapport meer insturen.");
                return;
            }

            var reportForm = new ReportPostForm();
            var result = reportForm.ShowDialog();
            if (result == DialogResult.OK)
            {
                //try to add report to database and show appropriate message
                MessageBox.Show(_logicPost.Report(_logicGuest.GetGuestByEvent(_event, _activeUser.ID), _post,
                    reportForm.ReasonReturnValue)
                    ? "Rapport succesvol verzonden. Bedankt voor u feedback!"
                    : "Er is iets fout gegaan met het doorvoeren van dit rapport, onze excuses hiervoor.");
                RefreshSocialSystem();
            }
        }
        private void lbLike_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (_activeUser != null)
                _logicPost.Like(_activeUser, _post);
            else
                _logicPost.Like(_admin, _post);
            RefreshSocialSystem();
        }
        private void lblUnLike_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if(_activeUser != null) 
                _logicPost.UnLike(_activeUser, _post);
            else
                _logicPost.UnLike(_admin, _post);
            RefreshSocialSystem();
        }
        private void lblDeletePost_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if(_logicPost.DeletePost(_post))
                MessageBox.Show(@"Post of reactie succesvol verwijderd");
            else
                MessageBox.Show(@"Er is iets mis gegaan");
            //Controls.Remove(this.Name);
        }
        private void lbReaction_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (_activeUser != null)
            {
                // guest post reaction on post
                extended = new PostFeedExtended(_post, _event, _activeUser);
            }
            else
            {
                // admin post reaction on post
                extended = new PostFeedExtended(_post, _event, _admin);
            }

            ExtendedForm expost = new ExtendedForm();
            expost.Controls.Add(extended);
            expost.ShowDialog();
        }
        /// <summary>
        /// Refresh everything on the user control
        /// </summary>
        private void RefreshSocialSystem()
        {
            List<Report> reports = _logicReport.GetAllByPost(_post);
            List<int> likes = _logicPost.GetAllLikes(_post);
            lbLike.Visible = true;
            lblUnLike.Visible = false;

            if (_activeUser != null)
            {
                // Guest rights
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
            }
            else
            {
                // Admin rights
                lbReport.Visible = false;
                lblDeletePost.Visible = true;

                if (likes != null)
                {
                    foreach (int i in likes)
                    {
                        if (i == _admin.ID)
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
            }

            tbMessage.Text = _post.Content;
            lblAuteurNaam.Text = _guestPost.Name + @" " + _guestPost.Surname;
            lblDatum.Text = @"Geplaatst op " + _post.Date.ToString("dd/MM/yyyy");
            ShowMedia(_post);
        }
        /// <summary>
        /// This method is use to load image from FTP server
        /// </summary>
        /// <param name="post"></param>
        private void ShowMedia(Post post)
        {
            if (post.MediaID != 0)
            {
                _media = _logicMedia.GetById(post.MediaID);
                if (_media.Type == MediaType.Image) // Image
                {
                    string ftpPath = @"/" + post.EventID + @"/" + post.GuestID + @"/" + _media.Path;
                    pbMediaMessage.ImageLocation = FtpHelper.ServerHardLogin + @"/" + ftpPath;
                    pbMediaMessage.SizeMode = PictureBoxSizeMode.Zoom;
                }else if (_media.Type == MediaType.Audio)   // Audio
                {
                    pbMediaMessage.ImageLocation = FtpHelper.ServerHardLogin + @"/mp3.jpg";
                    pbMediaMessage.SizeMode = PictureBoxSizeMode.Zoom;
                }
                else
                { 
                    // MP4 (video)
                    pbMediaMessage.ImageLocation = FtpHelper.ServerHardLogin + @"/mp4.png";
                    pbMediaMessage.SizeMode = PictureBoxSizeMode.Zoom;
                }
            }
            else
            {
                // Without media show nothin
                pbMediaMessage.Visible = false;
                lblDownloadMedia.Visible = false;
                tbMessage.Width = 614;
                lblUnLike.Location = new Point(569, lblUnLike.Location.Y);
                lbLike.Location = new Point(584, lbLike.Location.Y);
                lblDeletePost.Location = new Point(517, lblDeletePost.Location.Y);
                lbReport.Location = new Point(517, lbReport.Location.Y);
                lbReaction.Location = new Point(455, lbReaction.Location.Y);
            }
        }
        /// <summary>
        /// This method downloads the file of the FTP server
        /// </summary>
        /// <param name="post"></param>
        private void DownloadMedia(Post post)
        {
            if (post.MediaID != 0)
            {
                _media = _logicMedia.GetById(post.MediaID);

                FolderBrowserDialog saveMedia = new FolderBrowserDialog();

                if (saveMedia.ShowDialog() == DialogResult.OK)
                {
                    string pathSelected = saveMedia.SelectedPath;
                    FtpHelper.DownloadFile(FtpHelper.ServerHardLogin + @"/" + @"/" + post.EventID + @"/" + post.GuestID + @"/" + _media.Path, pathSelected + "/" + _media.Path);
                    MessageBox.Show(@"Bestand is succesvol gedownload");
                }
            }
        }
        private bool CheckReportStatus(Post post, PostLogic postLogic, ReportOracleContext reportContext)
        {
            List<Report> allReportsByPost = reportContext.GetAllByPost(post);
            if (allReportsByPost.Count >= 5)
            {
                post.Visible = false;
                postLogic.UpdatePost(post);
                return true;
            }
            return false;

        }
    }
}
