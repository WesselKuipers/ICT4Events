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
        private readonly ReportOracleContext _logicReport;
        private readonly List<Post> _getAllPostByEvent;

        public ReportSection(User admin, Event ev)
        {
            InitializeComponent();
            _admin = admin;
            _event = ev;
            _logicPost = new PostLogic();
            _logicReport = new ReportOracleContext();
            _getAllPostByEvent = _logicPost.GetAllByEvent(_event);
            lblWelkom.Text = $"Welkom bij de rapporten overzicht,  {_admin.Name} {_admin.Surname}";
        }

        private void ReportSection_Load(object sender, System.EventArgs e)
        {
            RefreshReportSystem(_getAllPostByEvent, _logicReport);
        }

        private void RefreshReportSystem(List<Post> getAllPostByEvent, ReportOracleContext report)
        {
            lbReportsUnder5.Items.Clear();
            lbUnvisiblePosts.Items.Clear();
            lbReportsAbove5.Items.Clear();
            // Under 5 listbox
            foreach (var p in getAllPostByEvent)
            {
                var tempListOfReports = report.GetAllByPost(p);
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
            // Above 5 lisbox
            foreach (var p in getAllPostByEvent)
            {
                var tempListOfReports = report.GetAllByPost(p);
                if (tempListOfReports.Count >= 5)
                {
                    lbReportsAbove5.Items.Add(p);
                }
            }
        }
        private void WatchPost(Post post)
        {
            MessageBox.Show($"Content: {post.Content} | Datum: {post.Date.ToString("yyyy MMMM dd")} | GuestID: {post.GuestID}");
        }

        private void btHidePost_Click(object sender, System.EventArgs e)
        {
            Post post = (Post) lbReportsUnder5.SelectedItem;
            if (post != null)
            {
                var messageBoxResult = System.Windows.MessageBox.Show("Weet je het zeker?", "Verbergen?", System.Windows.MessageBoxButton.YesNo);
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
            RefreshReportSystem(_getAllPostByEvent, _logicReport);
        }
        private void btZichtbaarMaken_Click(object sender, System.EventArgs e)
        {
            Post post = (Post)lbUnvisiblePosts.SelectedItem;
            if (post != null)
            {
                var messageBoxResult = System.Windows.MessageBox.Show("Weet je het zeker?", "Zichtbaar maken?", System.Windows.MessageBoxButton.YesNo);
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
            RefreshReportSystem(_getAllPostByEvent, _logicReport);
        }
        private void btRemoveReports_Click(object sender, System.EventArgs e)
        {
            Post post = (Post)lbReportsAbove5.SelectedItem;
            if (post != null)
            {
                var messageBoxResult = System.Windows.MessageBox.Show("Weet je het zeker?", "Zichtbaar maken & Reports verwijderen?", System.Windows.MessageBoxButton.YesNo);
                if (messageBoxResult == MessageBoxResult.Yes)
                {
                    post.Visible = true;
                    _logicPost.UpdatePost(post);
                    var tempListOfReports = _logicReport.GetAllByPost(post);
                    foreach (Report rep in tempListOfReports)
                    {
                        _logicReport.Delete(rep);
                    }
                }
                RefreshReportSystem(_getAllPostByEvent, _logicReport);
            }
            else
            {
                MessageBox.Show($"Selecteer eerst een post voordat je het weer zichtbaar wilt maken.");
            }
        }

        private void btPostWatch1_Click(object sender, System.EventArgs e)
        {
            Post post = (Post)lbReportsUnder5.SelectedItem;
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
            Post post = (Post)lbReportsAbove5.SelectedItem;
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
            Post post = (Post)lbUnvisiblePosts.SelectedItem;
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
