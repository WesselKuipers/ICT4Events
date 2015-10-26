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
            // default views

            // Edit user tab
            tabEditUser.Controls.Add(new UcEditUser(_user));

            // Edit Password tab
            // TODO

            // check for permission type and show appropriate tabs
            switch (_user.Permission)
            {
                case PermissionType.User:
                    // show all default views
                    break;

                case PermissionType.Employee:
                    // show employee tabs
                    break;

                case PermissionType.Administrator:
                    // Manage Permissions tab
                    var managePermissionsTab = new TabPage("Beheer Permissions");
                    tcAccountsystem.TabPages.Add(managePermissionsTab);
                    managePermissionsTab.Controls.Add(new UcManagePermissions(_user));

                    // Delete user tab
                    var deleteUserTab = new TabPage("Verwijder Accounts");
                    tcAccountsystem.TabPages.Add(deleteUserTab);
                    deleteUserTab.Controls.Add(new UcDeleteUser());

                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
