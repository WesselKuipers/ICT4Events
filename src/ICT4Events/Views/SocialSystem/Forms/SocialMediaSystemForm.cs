using System;
using System.Windows.Forms;
using ICT4Events.Views.SocialSystem.Controls;
using SharedModels.Models;

namespace ICT4Events.Views.SocialSystem.Forms
{
    public partial class SocialMediaSystemForm : Form
    {
        private readonly User _user;
        private readonly Event _event;

        public SocialMediaSystemForm(User user, Event ev)
        {
            InitializeComponent();
            _user = user;
            _event = ev;
        }

        private void SocialMediaSystemForm_Load(object sender, EventArgs e)
        {
            TimeLine timeLine = new TimeLine(_user, _event);
            tbTimeLine.Controls.Add(timeLine);
            MakePost makePost = new MakePost(_user, _event);
            tbMakePost.Controls.Add(makePost);
        }
    }
}
