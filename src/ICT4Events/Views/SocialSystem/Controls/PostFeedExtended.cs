using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Documents;
using System.Windows.Forms;
using ICT4Events.Views.SocialSystem.Forms;
using SharedModels.Data.OracleContexts;
using SharedModels.Enums;
using SharedModels.FTP;
using SharedModels.Logic;
using SharedModels.Models;

namespace ICT4Events.Views.SocialSystem.Controls
{
    public partial class PostFeedExtended : UserControl
    {
        private readonly Post _post;
        private readonly Event _event;
        private readonly Guest _activeUser;
        private readonly User _admin;
        private Media _media;
        private readonly PostLogic _logicPost;
        private readonly ReportOracleContext _reportContext;

        public PostFeedExtended(Post post, Event ev, Guest active)
        {
            InitializeComponent();
            _logicPost = new PostLogic();
            _reportContext = new ReportOracleContext();

            _post = post;
            _event = ev;

            // Currently signed in guest
            _activeUser = active;
        }

        public PostFeedExtended(Post post, Event ev, User admin)
        {
            InitializeComponent();
            _logicPost = new PostLogic();
            _reportContext = new ReportOracleContext();

            _post = post;
            _event = ev;
            _admin = admin;
        }

        private void PostFeedExtended_Load(object sender, EventArgs e)
        {
            tbPanelMainPost.Controls.Add(_activeUser != null
                ? new PostFeed(_post, _event, _activeUser, true)
                : new PostFeed(_post, _event, _admin, true));

            LoadReplies();
        }

        private void btReply_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbReplyMessage.Text))
            {
                var mess = tbReplyMessage.Text;
                AddReply(mess);
            }
            else
            {
                MessageBox.Show("Bericht is verplicht!");
            }
        }

        /// <summary>
        /// Adds a reply to database
        /// </summary>
        /// <param name="message">Content of the reply</param>
        private void AddReply(string message)
        {
            Reply r;
            r = _activeUser != null 
                ? new Reply(0, _activeUser.ID, _event.ID, 0, _post.ID, DateTime.Now, true, message)
                : new Reply(0, _admin.ID, _event.ID, 0, _post.ID, DateTime.Now, true, message);

            if (_logicPost.InsertPost(r) == null)
                MessageBox.Show(@"Er is iets misgegaan");
            LoadReplies();
        }

        private void LoadReplies()
        {
            var replies = _logicPost.GetRepliesByPost(_post);
            tbPanelReplies.RowCount = 1;
            tbPanelReplies.Controls.Clear();
            var i = 0;
            foreach (var p in replies)
            {
                CheckReportStatus(p, _logicPost, _reportContext);

                if (p.MainPostID != _post.ID) continue;
                if (!p.Visible) continue;
                if (i > replies.Count) continue;
                tbPanelReplies.RowCount += 1;
                tbPanelReplies.Controls.Add(new PostFeed(p, _event, _activeUser, true), 0, i);
                i++;
            }
        }

        private void CheckReportStatus(Post post, PostLogic postLogic, ReportOracleContext reportContext)
        {
            var allReports = reportContext.GetAllByPost(post);
            if (allReports.Count >= 5) post.Visible = false;
            postLogic.UpdatePost(post);
        }

    }
}
