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
        private readonly Guest _guestPost;
        private readonly User _admin;
        private readonly Guest _activeUser;
        private Media _media;
        private readonly MediaOracleContext _logicMedia;
        private readonly PostLogic _logicPost;
        private readonly GuestLogic _logicGuest;
        private readonly ReportOracleContext _logicReport;
        private PostFeedExtended extended;


        private PostFeed(Post post, Event ev, bool reply)
        {
            InitializeComponent();
            _logicMedia = new MediaOracleContext();
            _logicPost = new PostLogic();
            _logicGuest = new GuestLogic(new GuestOracleContext());
            _logicReport = new ReportOracleContext();

            _post = post;
            _event = ev;

            lbReaction.Visible = !reply;
        }

        public PostFeed(Post post, Event ev, Guest active, bool reply) : this(post, ev, reply)
        {
            // Currently signed in guest
            _activeUser = active;

            // User of the post
            _guestPost = _logicGuest.GetGuestByEvent(_event, _post.GuestID);
        }
        public PostFeed(Post post, Event ev, User admin, bool reply) : this(post, ev, reply)
        {
            // Currently signed in administrator
            _admin = admin;

            // User of the post
            _guestPost = _logicGuest.GetGuestByEvent(_event, _post.GuestID);
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
            MessageBox.Show(_logicPost.DeletePost(_post)
                ? "Post of reactie succesvol verwijderd"
                : "Er is iets mis gegaan");

            //Controls.Remove(this.Name);
        }

        private void lbReaction_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            extended = _activeUser != null
                ? new PostFeedExtended(_post, _event, _activeUser)
                : new PostFeedExtended(_post, _event, _admin);

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
                    foreach (var r in reports.Where(r => r.GuestID == _activeUser.ID))
                    {
                        lbReport.Enabled = false;
                    }
                }
                if (likes != null)
                {
                    foreach (var i in likes.Where(i => i == _activeUser.ID))
                    {
                        lbLike.Visible = false;
                        lblUnLike.Visible = true;
                    }
                    lblCountLikes.Text = $"{likes.Count} mens(en) vinden dit leuk";
                }
                else
                {
                    lblCountLikes.Text = "0 mensen vinden dit leuk";
                }
            }
            else // TODO: Refactor this to avoid duplicate code
            {
                // Admin rights
                lbReport.Visible = false;
                lblDeletePost.Visible = true;

                if (likes != null)
                {
                    foreach (var i in likes.Where(i => i == _admin.ID))
                    {
                        lbLike.Visible = false;
                        lblUnLike.Visible = true;
                    }

                    lblCountLikes.Text = $"{likes.Count} mens(en) vinden dit leuk";
                }
                else
                {
                    lblCountLikes.Text = "0 mensen vinden dit leuk";
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
                        pbMediaMessage.ImageLocation = FtpHelper.ServerHardLogin + @"/mp3.jpg";
                        break;
                    default:
                        // Show mp4 icon
                        pbMediaMessage.ImageLocation = $"{FtpHelper.ServerHardLogin}/mp4.png";
                        break;
                }
            }
            else
            {
                // Post doesn't have any attached media
                pbMediaMessage.Visible = false;
                lblDownloadMedia.Visible = false;

                tbMessage.Width = 614;

                lblUnLike.Location = new Point(569, lblUnLike.Location.Y);
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

            if (FtpHelper.DownloadFile($"/{post.EventID}/{post.GuestID}/{_media.Path}", $"{pathSelected}/{_media.Path}"))
                MessageBox.Show("Bestand is succesvol gedownload");
            else
                MessageBox.Show("ERROR: Er is iets misgegaan.");
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
