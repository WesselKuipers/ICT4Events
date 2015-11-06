using System;
using System.Windows.Forms;
using SharedModels.Enums;
using SharedModels.Models;

namespace ICT4Events.Views.SocialSystem.Controls
{
    public partial class Catalogue : UserControl
    {
        private readonly User _user;
        private readonly Event _event;

        public Catalogue(Event ev,User user)
        {
            InitializeComponent();
            _user = user;
            _event = ev;
        }

        private void Catalogue_Load(object sender, EventArgs e)
        {
            if (_user.Permission == PermissionType.User)
            {
                
            }
        }
    }
}
