using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using SharedModels.Data.OracleContexts;
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
        private readonly PostLogic _logicPost;
        private readonly ReportOracleContext _reportContext;
        private List<Reply> _replies;

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
        /// <summary>
        /// Loads the replies
        /// </summary>
        private void LoadReplies()
        {
            _replies = _logicPost.GetRepliesByPost(_post).Where(p => p.Visible).OrderByDescending(x => x.Date).ToList();

            tbPanelReplies.Controls.Clear();
            tbPanelReplies.RowCount = 0;
            tbPanelReplies.RowStyles.Clear();
            tbPanelReplies.RowStyles.Add(new RowStyle(SizeType.AutoSize));

            foreach (var p in _replies)
            {
                tbPanelReplies.RowCount++;
                tbPanelReplies.Controls.Add(new PostFeed(p, _event, _activeUser, true), 0, tbPanelReplies.RowCount);
            }
        }
        /// <summary>
        /// Compare the exsist list with the new reply list
        /// </summary>
        private void CompareList()
        {
            var newListOfReplies = _logicPost.GetRepliesByPost(_post).Where(p => p.Visible).OrderByDescending(x => x.Date).ToList();
            if (!Equals(newListOfReplies.Count, _replies.Count))
            {
                LoadReplies();
            }
        }
        /// <summary>
        /// Ticking timer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tmrRefresh_Tick(object sender, EventArgs e)
        {
            CompareList();
        }
    }
}
