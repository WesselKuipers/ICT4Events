using System;
using System.Windows.Forms;
using ICT4Events.Views.SocialSystem.Controls;
using SharedModels.Models;

namespace ICT4Events.Views.SocialSystem.Forms
{
    public partial class SocialMediaSystemForm : Form
    {
        private readonly Guest _user;
        private readonly Event _event;
<<<<<<< HEAD
        public SocialMediaSystemForm(Guest user, Event ev)
=======

        public SocialMediaSystemForm(User user, Event ev)
>>>>>>> e61652cca6aceb8ab03cca4351b83eecf142b0c8
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
