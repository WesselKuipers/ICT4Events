using System;
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
            tbPanelReplies.Controls.Clear();
            var replies = _logicPost.GetRepliesByPost(_post);

            foreach (var p in replies.Where(p => p.Visible))
            {
                if (!p.Visible) continue;
                tbPanelReplies.Controls.Add(new PostFeed(p, _event, _activeUser, true), 0, ++tbPanelReplies.RowCount);
            }
        }

    }
}
