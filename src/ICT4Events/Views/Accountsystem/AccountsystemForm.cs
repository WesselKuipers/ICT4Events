using System;
using System.Windows.Forms;
using ICT4Events.Views.Accountsystem.Controls;
using SharedModels.Models;

namespace ICT4Events.Views.Accountsystem
{
    public partial class AccountSystemForm : Form
    {
        private readonly User _user;

        public AccountSystemForm(User user)
        {
            InitializeComponent();
            _user = user;
        }

        private void Accountsystem_Load(object sender, EventArgs e)
        {
            // Edit user tab
            var ucEditUser = new UcEditUser(_user);
            tabEditUser.Controls.Add(ucEditUser);

            
        }
    }
}
