using System;
using System.Windows.Forms;
using ICT4Events.Views.Accountsystem.Controls;
using SharedModels.Enums;
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
            // Edit user tab (default tab of tab control)
            tabEditUser.Controls.Add(new UcEditUser(_user));

            // Edit Password tab
            var changePassTab = new TabPage("Wijzig wachtwoord");
            tcAccountsystem.TabPages.Add(changePassTab);
            changePassTab.Controls.Add(new UcChangePassword(_user));

            // Only admins can see certain tabs
            if (_user.Permission == PermissionType.Administrator)
            {
                var managePermissionsTab = new TabPage("Beheer Permissions");
                tcAccountsystem.TabPages.Add(managePermissionsTab);
                managePermissionsTab.Controls.Add(new UcManagePermissions(_user));

                // Delete user tab
                var deleteUserTab = new TabPage("Verwijder Accounts");
                tcAccountsystem.TabPages.Add(deleteUserTab);
                deleteUserTab.Controls.Add(new UcDeleteUser());
            }
        }
    }
}
