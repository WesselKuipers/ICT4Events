using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using ICT4Events.Views.SocialSystem.Forms;
using SharedModels.Data.ContextInterfaces;
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
        private readonly User _postUser;
        private readonly User _activeUser;
        private Media _media;
        private readonly MediaOracleContext _logicMedia;
        private readonly PostLogic _logicPost;
        private readonly GuestLogic _logicGuest;
        private readonly ReportOracleContext _logicReport;
        private PostFeedExtended extended;

        public PostFeed(Post post, Event ev, User user, bool reply)
        {
            InitializeComponent();
            _logicMedia = new MediaOracleContext();
            _logicPost = new PostLogic();
            _logicGuest = new GuestLogic(new GuestOracleContext());
            _logicReport = new ReportOracleContext();

            _post = post;
            _event = ev;

            lbReaction.Visible = !reply;

            // Currently signed in user
            _activeUser = user;

            // Guest of the post
            _postUser = LogicCollection.UserLogic.GetById(_post.GuestID);
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
                MessageBox.Show("Bericht is verborgen. Je kunt geen rapport meer insturen.");
                return;
            }

            var reportForm = new ReportPostForm();
            var result = reportForm.ShowDialog();
            if (result != DialogResult.OK) return;

            // Try to add report to database and show appropriate message
            MessageBox.Show(_logicPost.Report(_logicGuest.GetGuestByEvent(_event, _activeUser.ID), _post,
                reportForm.ReasonReturnValue)
                ? "Rapport succesvol verzonden. Bedankt voor u feedback!"
                : "Er is iets fout gegaan met het doorvoeren van dit rapport, onze excuses hiervoor.");
            RefreshSocialSystem();
        }
        private void lbLike_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (_activeUser != null)
                _logicPost.Like(_activeUser.ID, _post);

            RefreshSocialSystem();
        }
        private void lblUnLike_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if(_activeUser != null) 
                _logicPost.Unlike(_activeUser.ID, _post);

            RefreshSocialSystem();
        }
        private void lblDeletePost_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show(_logicPost.DeletePost(_post)
                ? "Post of reactie succesvol verwijderd"
                : "Er is iets mis gegaan");

            //Controls.Remove(this.Name);
        }

        private void lbReaction_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            extended = new PostFeedExtended(_post, _event, _activeUser);

            var extendedPostform = new ExtendedForm();
            extendedPostform.tbpPostWatch.Controls.Add(extended);
            extendedPostform.ShowDialog();
        }
        /// <summary>
        /// Refresh everything on the user control
        /// </summary>
        private void RefreshSocialSystem()
        {
            var reports = _logicReport.GetAllByPost(_post);
            var likes = _logicPost.GetAllLikes(_post);

            lbLike.Visible = true;
            lblLikeStatus.Visible = false;

            // Guest rights
            if (_post.GuestID == _activeUser.ID)
            {
                lbReport.Visible = false;
                lblDeletePost.Visible = true;
            }

            if (reports != null)
            {
                foreach (var r in reports.Where(r => r.GuestID == _activeUser.ID))
                {
                    lbReport.Enabled = false;
                }
            }

            if (likes != null)
            {
                if (likes.Any(i => i == _activeUser.ID))
                {
                    lbLike.Visible = false;
                    lblLikeStatus.Visible = true;
                }

                lblCountLikes.Text = $"{likes.Count} mens(en) vinden dit leuk";
            }
            else
            {
                lblCountLikes.Text = "0 mensen vinden dit leuk";
            }

            if (_activeUser.Permission == PermissionType.Employee ||
            _activeUser.Permission == PermissionType.Administrator)
            {
                lbReport.Visible = false;
                lblDeletePost.Visible = true;
            }

            tbMessage.Text = _post.Content;
            lblAuteurNaam.Text = _postUser.Name + @" " + _postUser.Surname;
            lblDatum.Text = @"Geplaatst op " + _post.Date.ToString("dd/MM/yyyy");
            ShowMedia(_post);
        }
        /// <summary>
        /// This method is use to load image from FTP server
        /// </summary>
        /// <param name="post">The post to look up the media of</param>
        private void ShowMedia(Post post)
        {
            if (post.MediaID != 0)
            {
                _media = _logicMedia.GetById(post.MediaID);
                switch (_media.Type)
                {
                    case MediaType.Image:
                        var ftpPath = $"/{post.EventID}/{post.GuestID}/{_media.Path}";
                        pbMediaMessage.ImageLocation = $"{FtpHelper.ServerHardLogin}/{ftpPath}";
                        break;
                    case MediaType.Audio:
                        // Show mp3 icon
                        pbMediaMessage.Image = Properties.Resources.mp3;
                        break;
                    default:
                        // Show mp4 icon
                        pbMediaMessage.Image = Properties.Resources.mp4;
                        break;
                }
            }
            else
            {
                // Post doesn't have any attached media
                pbMediaMessage.Visible = false;
                lblDownloadMedia.Visible = false;

                tbMessage.Width = 614;

                lblLikeStatus.Location = new Point(569, lblLikeStatus.Location.Y);
                lbLike.Location = new Point(584, lbLike.Location.Y);
                lblDeletePost.Location = new Point(505, lblDeletePost.Location.Y);
                lbReport.Location = new Point(505, lbReport.Location.Y);
                lbReaction.Location = new Point(440, lbReaction.Location.Y);
            }
        }
        /// <summary>
        /// This method downloads the file of the FTP server
        /// </summary>
        /// <param name="post"></param>
        private void DownloadMedia(Post post)
        {
            if (post.MediaID == 0) return;

            _media = _logicMedia.GetById(post.MediaID);

            var saveMedia = new FolderBrowserDialog();

            if (saveMedia.ShowDialog() != DialogResult.OK) return;

            var pathSelected = saveMedia.SelectedPath;

            MessageBox.Show(FtpHelper.DownloadFile($"/{post.EventID}/{post.GuestID}/{_media.Path}",
                $"{pathSelected}/{_media.Path}")
                ? "Bestand is succesvol gedownload"
                : "Er is iets misgegaan met het downloaden van deze media");
        }

        private bool CheckReportStatus(Post post, PostLogic postLogic, IReportContext reportContext)
        {
            var allReportsByPost = reportContext.GetAllByPost(post);
            if (allReportsByPost.Count < 5) return false;

            post.Visible = false;
            postLogic.UpdatePost(post);
            return true;
        }
    }
}
