using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SharedModels.Logic;
using SharedModels.Models;

namespace ICT4Events.Views.SocialSystem.Controls
{
    public partial class TimeLine : UserControl
    {
        private readonly Guest _user ;
        private readonly Event _event;
        private readonly PostLogic _logic;
        public TimeLine(Guest user, Event ev)
        {
            InitializeComponent();
            _user = user;
            _event = ev;
            _logic = new PostLogic();
        }

        private void TimeLine_Load(object sender, EventArgs e)
        {
            LoadPosts();
        }
        /// <summary>
        /// LOAD THE MAIN POSTS ON THE TIMELINE
        /// </summary>
        public void LoadPosts()
        {
            List<Post> allPost = _logic.GetAllByEvent(_event);
            int i = 0;
            foreach (Reply p in allPost)
            {
                if (p.MainPostID == 0)
                {
                    if (i <= 5)
                    {
                        tableLayoutPanel1.RowCount += 1;
                        tableLayoutPanel1.Controls.Add(new PostFeed(p, _event, _user), 0, i);
                        i++;
                    }
                }
            }
        }
    }
}
