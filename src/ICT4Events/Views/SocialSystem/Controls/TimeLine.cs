using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using SharedModels.Data.OracleContexts;
using SharedModels.Logic;
using SharedModels.Models;

namespace ICT4Events.Views.SocialSystem.Controls
{
    public partial class TimeLine : UserControl
    {
        private readonly Guest _user ;
        private readonly User _admin;
        private readonly Event _event;
        private readonly PostLogic _logic;
        private readonly ReportOracleContext _reportContext;

        private List<Post> Posts;

        public TimeLine(Guest user, Event ev)
        {
            InitializeComponent();
            _user = user;
            _event = ev;
            _logic = new PostLogic();
            _reportContext = new ReportOracleContext();
        }
        public TimeLine(User user, Event ev)
        {
            InitializeComponent();
            _admin = user;
            _event = ev;
            _logic = new PostLogic();
            _reportContext = new ReportOracleContext();
        }

        private void TimeLine_Load(object sender, EventArgs e)
        {
            LoadAllPosts();
        }
        /// <summary>
        /// Load the main post on the timeline 
        /// Eerst even dit
        /// </summary>
        private void LoadAllPosts()
        {
            Posts = _logic.GetAllByEvent(_event).Where(p => p.Visible).OrderByDescending(x => x.Date).ToList();
            foreach (Reply post in Posts)
            {
                LoadPost(post);
            }
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
                tableLayoutPanel1.Controls.Clear();
                foreach (Reply post in newListPosts)
                {
                    LoadPost(post);
                }
                Posts = newListPosts;
            }
        }

        private void LoadPost(Reply post)
        {
            var i = 0;
            if (post.MainPostID == 0)
            {
                if (i <= 5)
                {
                    // Post are getting loaded here on the timeline
                    tableLayoutPanel1.RowCount += 1;
                    if (_user != null)
                    {
                        tableLayoutPanel1.Controls.Add(new PostFeed(post, _event, _user, false), 0, i);
                    }
                    else
                    {
                        tableLayoutPanel1.Controls.Add(new PostFeed(post, _event, _admin, false), 0, i);
                    }
                    i++;
                }

            }
        }
    }
}
