using System;
using System.Collections.Generic;
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
    public partial class PostFeedExtended : UserControl
    {
        private readonly Post _post;
        private readonly Event _event;
        private readonly Guest _activeUser;
        private readonly User _admin;
        private Media _media;
        private readonly PostLogic _logicPost;

        public PostFeedExtended(Post post, Event ev, Guest active)
        {
            InitializeComponent();
            _logicPost = new PostLogic();

            _post = post;
            _event = ev;
            // CURRENT "GUEST" SIGNED IN.
            _activeUser = active;
        }

        public PostFeedExtended(Post post, Event ev, User admin)
        {
            InitializeComponent();
            _logicPost = new PostLogic();

            _post = post;
            _event = ev;
            // CURRENT "GUEST" SIGNED IN.
            _admin = admin;
        }

        private void PostFeedExtended_Load(object sender, EventArgs e)
        {
            if (_activeUser != null)
                tbPanelMainPost.Controls.Add(new PostFeed(_post, _event, _activeUser, true));
            else
                tbPanelMainPost.Controls.Add(new PostFeed(_post, _event, _admin, true));

            LoadReplies();
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
            Reply r = null;
            if (_activeUser != null)
            {
                r = new Reply(0, _activeUser.ID, _event.ID, 0, _post.ID, DateTime.Now, true, message);
            }
            else
            {
                r = new Reply(0, _admin.ID, _event.ID, 0, _post.ID, DateTime.Now, true, message);
            }

            if (_logicPost.InsertPost(r) == null)
                MessageBox.Show(@"Er is iets misgegaan");
            LoadReplies();
        }

        public void LoadReplies()
        {
            List<Reply> allReply = _logicPost.GetRepliesByPost(_post);
            tbPanelReplies.Controls.Clear();
            tbPanelReplies.RowStyles.Clear();
            int i = 0;
            foreach (Reply p in allReply)
            {
                if (p.MainPostID == _post.ID)
                {
                    if (i <= allReply.Count)
                    {
                        tbPanelReplies.RowCount += 1;
                        tbPanelReplies.Controls.Add(new PostFeed(p, _event, _activeUser, true), 0, i);
                        i++;
                    }
                }
            }
        }

    }
}
