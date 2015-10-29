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
        private readonly User _admin;

        public SocialMediaSystemForm(Guest user, Event ev)
        {
            InitializeComponent();
            _user = user;
            _event = ev;
        }

        public SocialMediaSystemForm(User admin, Event ev)
        {
            InitializeComponent();
            _admin = admin;
            _event = ev;
        }
        
        private void SocialMediaSystemForm_Load(object sender, EventArgs e)
        {
            if (_user != null)
            {
                TimeLine timeLine = new TimeLine(_user, _event);
                timeLine.Dock = DockStyle.Fill;
                tbTimeLine.Controls.Add(timeLine);

                MakePost makePost = new MakePost(_user, _event);
                makePost.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top);
                tbMakePost.Controls.Add(makePost);
            }
            else
            {
                
            }
        }
    }
}
