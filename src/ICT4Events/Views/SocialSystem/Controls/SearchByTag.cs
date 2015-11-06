using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SharedModels.Logic;
using SharedModels.Models;

namespace ICT4Events.Views.SocialSystem.Controls
{
    public partial class SearchByTag : UserControl
    {
        private readonly User _user;
        private readonly Event _event;
        private readonly PostLogic _logic;

        public SearchByTag(User user, Event ev)
        {
            InitializeComponent();
            _user = user;
            _event = ev;
            _logic = new PostLogic();
        }

        private void SearchByTag_Load(object sender, EventArgs e)
        {
            lblNoPostsFound.Visible = false;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            panelPosts.Controls.Clear();

            if (!string.IsNullOrWhiteSpace(txtTag.Text))
            {
                lblNoPostsFound.Visible = false;

                var i = 1;
                foreach(Reply post in _logic.GetPostsByTag(txtTag.Text.ToLower()))
                {
                    if (post.Visible && i <= 5 && post.MainPostID == 0)
                    {
                        panelPosts.RowCount += 1;
                        panelPosts.Controls.Add(new PostFeed(post, _event, _user, false), 0, i);
                        ++i;
                    }
                }

                // if no posts are added to panel show no posts found label
                if (i == 1) lblNoPostsFound.Visible = true;
            }
            else
            {
                panelPosts.Controls.Clear();
                lblNoPostsFound.Visible = true;
            }
        }
    }
}
