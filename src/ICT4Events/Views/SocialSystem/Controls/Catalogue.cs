using System;
using System.Windows.Forms;
using SharedModels.Models;

namespace ICT4Events.Views.SocialSystem.Controls
{
    public partial class Catalogue : UserControl
    {
        private readonly User _activeUser;
        private readonly Event _event;

        public Catalogue(Event ev,User activeUser)
        {
            InitializeComponent();
            _activeUser = activeUser;
            _event = ev;
        }

        private void Catalogue_Load(object sender, EventArgs e)
        {

        }
    }
}
