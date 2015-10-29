using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ICT4Events.Views.SocialSystem.Forms;
using SharedModels.Data.OracleContexts;
using SharedModels.FTP;
using SharedModels.Logic;
using SharedModels.Models;

namespace ICT4Events.Views.SocialSystem.Controls
{
    public partial class ReplyPost : UserControl
    {
        private readonly Post _post;
        private readonly Event _event;
        private readonly Guest _guest;
        private readonly Guest _activeUser;
        private Media _media;
        private readonly MediaOracleContext _logicMedia;
        private readonly PostLogic _logicPost;
        private readonly GuestLogic _logicGuest;
        private readonly ReportOracleContext _logicReport;

        public ReplyPost(Post post, Event ev, Guest active)
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
            _guest = _logicGuest.GetGuestByEvent(_event, _post.GuestID);
        }

        private void lbReport_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var reportForm = new ReportPostForm();
            var result = reportForm.ShowDialog();
            if (result == DialogResult.OK)
            {
                //try to add report to database and show appropriate message
                MessageBox.Show(_logicPost.Report(_logicGuest.GetGuestByEvent(_event, _activeUser.ID), _post, reportForm.ReasonReturnValue)
                   ? "Rapport succesvol verzonden. Bedankt voor u feedback!"
                   : "Er is iets fout gegaan met het doorvoeren van dit rapport, onze excuses hiervoor.");
            }
            RefreshSocialSystem();
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
            {
                MessageBox.Show(@"Post succesvol verwijderd");
            }
            else
            {
                MessageBox.Show(@"Er is iets mis gegaan");
            }
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
        }

        private void ReplyPost_Load(object sender, EventArgs e)
        {
            RefreshSocialSystem();
        }
    }
}
