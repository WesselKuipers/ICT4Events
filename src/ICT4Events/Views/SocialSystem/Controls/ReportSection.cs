using System.Collections.Generic;
using System.Windows;
using System.Windows.Forms;
using SharedModels.Data.OracleContexts;
using SharedModels.Logic;
using SharedModels.Models;
using MessageBox = System.Windows.Forms.MessageBox;

namespace ICT4Events.Views.SocialSystem.Controls
{
    public partial class ReportSection : UserControl
    {
        private readonly User _admin;
        private readonly Event _event;
        private readonly PostLogic _logicPost;
        private readonly List<Post> _getAllPostByEvent;

        public ReportSection(User admin, Event ev)
        {
            InitializeComponent();
            _admin = admin;
            _event = ev;
            _logicPost = new PostLogic();
            _getAllPostByEvent = _logicPost.GetAllByEvent(_event);
            lblWelkom.Text = $"Welkom bij de rapporten overzicht,  {_admin.Name} {_admin.Surname}";
        }

        private void ReportSection_Load(object sender, System.EventArgs e)
        {
            RefreshReportSystem(_getAllPostByEvent);
        }

        private void RefreshReportSystem(List<Post> getAllPostByEvent)
        {
            lbReportsUnder5.Items.Clear();
            lbUnvisiblePosts.Items.Clear();
            lbReportsAbove5.Items.Clear();
            lbAllPosts.Items.Clear();

            // Under 5 listbox
            foreach (var p in getAllPostByEvent)
            {
                var tempListOfReports = LogicCollection.PostLogic.GetReportsByPost(p);
                if (tempListOfReports.Count >= 1 && tempListOfReports.Count < 5 && p.Visible)
                {
                    lbReportsUnder5.Items.Add(p);
                }
            }

            // Invisible listbox
            foreach (var p in getAllPostByEvent)
            {
                if (!p.Visible)
                {
                    lbUnvisiblePosts.Items.Add(p);
                }
            }

            // Above 5 listbox
            foreach (var p in getAllPostByEvent)
            {
                var tempListOfReports = LogicCollection.PostLogic.GetReportsByPost(p);
                if (tempListOfReports.Count >= 5)
                {
                    lbReportsAbove5.Items.Add(p);
                }
            }

            foreach (var p in getAllPostByEvent)
            {
                lbAllPosts.Items.Add(p);
            }
            lblTotal.Text = $"Totaal aantal posts: {getAllPostByEvent.Count} posts";
        }

        private void WatchPost(Post post)
        {
            var listOfReports = LogicCollection.PostLogic.GetReportsByPost(post);
            if (listOfReports.Count >= 1)
            {
                var rep = string.Empty;
                for (var i = 0; i < listOfReports.Count; i++)
                {
                    rep += $"Report {i + 1}: {listOfReports[i].Reason}\r\n";
                }
                MessageBox.Show($"Inhoud bericht:\r\n{post.Content}\r\nDatum: {post.Date.ToString("dd MMMM yyyy")}\r\nGuestID: {post.GuestID}\r\n\r\n{rep}");
            }
            else
            {
                MessageBox.Show($"{post.Content}\r\nDatum: {post.Date.ToString("dd MMMM yyyy")}\r\nGuestID: {post.GuestID}");
            }
        }

        private void btHidePost_Click(object sender, System.EventArgs e)
        {
            var post = (Post) lbReportsUnder5.SelectedItem;
            if (post != null)
            {
                var messageBoxResult = System.Windows.MessageBox.Show("Weet je het zeker?", "Verbergen?", MessageBoxButton.YesNo);
                if (messageBoxResult == MessageBoxResult.Yes)
                {
                    post.Visible = false;
                    _logicPost.UpdatePost(post);
                }
            }
            else
            {
                MessageBox.Show($"Selecteer eerst een post voordat je het wilt verbergen.");
            }
            RefreshReportSystem(_getAllPostByEvent);
        }
        private void btZichtbaarMaken_Click(object sender, System.EventArgs e)
        {
            var post = (Post)lbUnvisiblePosts.SelectedItem;
            if (post != null)
            {
                var messageBoxResult = System.Windows.MessageBox.Show("Weet je het zeker?", "Zichtbaar maken?", MessageBoxButton.YesNo);
                if (messageBoxResult == MessageBoxResult.Yes)
                {
                    post.Visible = true;
                    _logicPost.UpdatePost(post);
                }
            }
            else
            {
                MessageBox.Show($"Selecteer eerst een post voordat je het weer zichtbaar wilt maken.");
            }
            RefreshReportSystem(_getAllPostByEvent);
        }
        private void btRemoveReports_Click(object sender, System.EventArgs e)
        {
            var post = (Post)lbReportsAbove5.SelectedItem;
            if (post != null)
            {
                var messageBoxResult = System.Windows.MessageBox.Show("Weet je het zeker?", "Zichtbaar maken & Reports verwijderen?", MessageBoxButton.YesNo);
                if (messageBoxResult == MessageBoxResult.Yes)
                {
                    post.Visible = true;
                    _logicPost.UpdatePost(post);
                    var tempListOfReports = LogicCollection.PostLogic.GetReportsByPost(post);
                    foreach (var rep in tempListOfReports)
                    {
                        LogicCollection.PostLogic.DeleteReport(rep);
                    }
                }
                RefreshReportSystem(_getAllPostByEvent);
            }
            else
            {
                MessageBox.Show($"Selecteer eerst een post voordat je het weer zichtbaar wilt maken.");
            }
        }

        private void btPostWatch1_Click(object sender, System.EventArgs e)
        {
            var post = (Post)lbReportsUnder5.SelectedItem;
            if (post != null)
            {
                WatchPost(post);
            }
            else
            {
                MessageBox.Show($"Selecteer eerst een post voordat je het weer zichtbaar wilt maken.");
            }
        }
        private void btPostWatch2_Click(object sender, System.EventArgs e)
        {
            var post = (Post)lbReportsAbove5.SelectedItem;
            if (post != null)
            {
                WatchPost(post);
            }
            else
            {
                MessageBox.Show($"Selecteer eerst een post voordat je het weer zichtbaar wilt maken.");
            }
        }
        private void btPostWatch3_Click(object sender, System.EventArgs e)
        {
            var post = (Post)lbUnvisiblePosts.SelectedItem;
            if (post != null)
            {
                WatchPost(post);
            }
            else
            {
                MessageBox.Show($"Selecteer eerst een post voordat je het weer zichtbaar wilt maken.");
            }
        }
    }
}
