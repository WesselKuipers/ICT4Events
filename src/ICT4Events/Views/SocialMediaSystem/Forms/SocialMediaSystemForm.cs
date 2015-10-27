using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ICT4Events.Views.SocialMediaSystem.Controls;
using SharedModels.Models;

namespace ICT4Events.Views.SocialMediaSystem.Forms
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
        }
    }
}
