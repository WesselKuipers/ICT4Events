using System;
using System.Linq;
using System.Windows.Forms;
using SharedModels.Enums;
using SharedModels.Logic;
using SharedModels.Models;

namespace ICT4Events.Views.Accountsystem.Controls
{
    public partial class UcManagePermissions : UserControl
    {
        private readonly User _user;
        private readonly UserLogic _logic;

        public UcManagePermissions(User user)
        {
            InitializeComponent();
            _user = user;
            _logic = new UserLogic();
        }

        private void ucManagePermissions_Load(object sender, EventArgs e)
        {
            btnUpdatePermissions.Enabled = false;

            foreach (var user in _logic.AllUsers.Where(user => user.ID != _user.ID))
            {
                lbUsers.Items.Add(user);
            }

            foreach (var permissiontype in Enum.GetValues(typeof(PermissionType)))
            {
                cbPermTypes.Items.Add(permissiontype);
            }

            lbUsers.SelectedIndex = 0;
            var selUser = (User) lbUsers.SelectedItem;
            cbPermTypes.SelectedItem = selUser.Permission;
        }

        private void lbUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (GetSelectedUser() != null)
            {
                cbPermTypes.SelectedItem = GetSelectedUser().Permission;
                btnUpdatePermissions.Enabled = true;
            }
            else
            {
                cbPermTypes.SelectedText = "";
                btnUpdatePermissions.Enabled = false;
            }
        }

        private User GetSelectedUser()
        {
            if (lbUsers.SelectedItem is User)
            {
                return lbUsers.SelectedItem as User;
            }
            return null;
        }

        private void btnUpdatePermissions_Click(object sender, EventArgs e)
        {
            if (GetSelectedUser() != null)
            {
                _logic.UpdateUser(GetSelectedUser());
            }
            else
            {
                MessageBox.Show("Selecteer eerst een useraccount");
            }
        }
    }
}
