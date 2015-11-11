using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
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

        private List<Post> _posts;

        public TimeLine(User user, Event ev)
        {
            InitializeComponent();
            _user = user;
            _event = ev;
            _logic = new PostLogic();
        }

        private void TimeLine_Load(object sender, EventArgs e)
        {
            _posts = _logic.GetAllByEvent(_event).Where(p => p.Visible).OrderByDescending(x => x.Date).ToList();
            LoadAllPosts(_posts);
        }

        private void tmrRefresh_Tick(object sender, EventArgs e)
        {
            CompareAndRefreshPosts();
        }

        private void CompareAndRefreshPosts()
        {
            var newPosts = _logic.GetAllByEvent(_event).Where(p => p.Visible).OrderByDescending(x => x.Date).ToList();
            if (_posts.SequenceEqual(newPosts, new PostComparer())) return;
            var postIDs = _posts.Select(x => x.ID);

            foreach (var post in newPosts.Where(post => !postIDs.Contains(post.ID))) // Adds all new posts to the timeline
            {
                tableLayoutPanel1.RowCount++;
                tableLayoutPanel1.Controls.Add(new PostFeed(post, _event, _user, false), 0, 0);
            }

            foreach (var feed in tableLayoutPanel1.Controls.OfType<PostFeed>().Where(feed => !newPosts.Select(y => y.ID).Contains(feed.Post.ID)))
            {
                // Removes all posts that aren't present in the new list of posts
                tableLayoutPanel1.RowCount--;
                tableLayoutPanel1.Controls.Remove(feed);
            }

            foreach (var post in newPosts)
            {
                if (postIDs.Contains(post.ID))
                {
                    if (post.MediaID != _posts.First(p => p.ID == post.ID).MediaID)
                    {
                        foreach (
                            var row in
                                tableLayoutPanel1.Controls.OfType<PostFeed>().Where(feed => feed.Post.ID == post.ID))
                        {
                            row.Post.MediaID = 0;
                            row.pbMediaMessage.Visible = false;
                            // Post doesn't have any attached media
                            row.pbMediaMessage.Visible = false;
                            row.lblDownloadMedia.Visible = false;

                            row.tbMessage.Width = 614;

                            row.lblLikeStatus.Location = new Point(545, row.lblLikeStatus.Location.Y);
                            row.lbLike.Location = new Point(560, row.lbLike.Location.Y);

                            row.lblDeletePost.Location = new Point(481, row.lblDeletePost.Location.Y);
                            row.lbReport.Location = new Point(481, row.lbReport.Location.Y);

                            row.lbReaction.Location = new Point(420, row.lbReaction.Location.Y);
                        }
                    }

                    if (post.Visible != _posts.First(p => p.ID == post.ID).Visible)
                    {
                        foreach (
                            var row in
                                tableLayoutPanel1.Controls.OfType<PostFeed>().Where(feed => feed.Post.ID == post.ID))
                        {
                            tableLayoutPanel1.RowCount--;
                            tableLayoutPanel1.Controls.Remove(row);
                        }
                    }
                }
            }
            _posts = newPosts;
        }

        /// <summary>
        /// Clears the timeline and populates it with posts
        /// </summary>
        private void LoadAllPosts(IEnumerable<Post> postsList)
        {
            tableLayoutPanel1.Controls.Clear();
            foreach (var post in postsList)
            {
                // Post are getting loaded here on the timeline
                tableLayoutPanel1.RowCount++;
                tableLayoutPanel1.Controls.Add(new PostFeed(post, _event, _user, false), 0,
                    tableLayoutPanel1.RowCount + 1);
            }
        }
    }
}
