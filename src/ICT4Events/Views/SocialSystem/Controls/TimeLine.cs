using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SharedModels.Models;
using SharedModels.Logic;

namespace ICT4Events.Views.SocialSystem.Controls
{
    public partial class TimeLine : UserControl
    {
        private readonly User _user ;
        private readonly Event _event;
        private readonly PostLogic _logic;
        public TimeLine(User user, Event ev)
        {
            InitializeComponent();
            _user = user;
            _event = ev;
            _logic = new PostLogic();
        }

        private void TimeLine_Load(object sender, EventArgs e)
        {
            List<Post> allPost = _logic.GetAllByEvent(_event);
            foreach (Post p in allPost)
            {
                textBox1.Text = textBox1.Text + p.Content + "\n";
            }
        }
    }
}
