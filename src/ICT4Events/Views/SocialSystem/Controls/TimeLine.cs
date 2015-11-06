using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using SharedModels.Logic;
using SharedModels.Models;

namespace ICT4Events.Views.SocialSystem.Controls
{
    public partial class TimeLine : UserControl
    {
        private readonly User _user ;
        private readonly Event _event;
        private readonly PostLogic _logic;

        private List<Post> Posts;

        public TimeLine(User user, Event ev)
        {
            InitializeComponent();
            _user = user;
            _event = ev;
            _logic = new PostLogic();
        }

        private void TimeLine_Load(object sender, EventArgs e)
        {
            Posts = _logic.GetAllByEvent(_event).Where(p => p.Visible).OrderByDescending(x => x.Date).ToList();
            LoadAllPosts(Posts);
        }

        private void tmrRefresh_Tick(object sender, EventArgs e)
        {
            CompareAndRefreshPosts();
        }

        private void CompareAndRefreshPosts()
        {
            var newListPosts = _logic.GetAllByEvent(_event).Where(p => p.Visible).OrderByDescending(x => x.Date).ToList();
            if(!Equals(newListPosts.Count, Posts.Count))
            {
                LoadAllPosts(newListPosts);
                Posts = newListPosts;
            }
        }

        /// <summary>
        /// Load the main post on the timeline 
        /// Eerst even dit
        /// </summary>
        private void LoadAllPosts(List<Post> PostsList)
        {
            foreach (Reply post in PostsList)
            {
               // Post are getting loaded here on the timeline
                tableLayoutPanel1.RowCount++;
                tableLayoutPanel1.Controls.Add(new PostFeed(post, _event, _user, false), 0,
                    tableLayoutPanel1.RowCount + 1);
            }
        }
    }
}
