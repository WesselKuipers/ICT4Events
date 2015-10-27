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

namespace ICT4Events.Views.SocialMediaSystem.Controls
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

        }
    }
}
