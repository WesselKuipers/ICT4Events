using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ICT4Events.view.Accountsystem.views;
using SharedModels.Models;

namespace ICT4Events.view.Accountsystem
{
    public partial class AccountsystemForm : Form
    {
        private readonly User _user;

        public AccountsystemForm(User user)
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
