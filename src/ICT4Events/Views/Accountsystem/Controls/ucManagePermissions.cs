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

            lbUsers.Items.AddRange(_logic.AllUsers.Where(user => user.ID != _user.ID).ToArray());

            cbPermTypes.DataSource = Enum.GetValues(typeof (PermissionType));
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
                cbPermTypes.SelectedText = string.Empty;
                btnUpdatePermissions.Enabled = false;
            }
        }

        private User GetSelectedUser()
        {
            return lbUsers.SelectedItem as User;
        }

        private void btnUpdatePermissions_Click(object sender, EventArgs e)
        {
            var user = GetSelectedUser();

            if (user != null)
            {
                var permission = (PermissionType)cbPermTypes.SelectedItem;
                user.Permission = permission;
                MessageBox.Show(_logic.UpdateUser(user)
                    ? "User is succesvol aangepast"
                    : "User is niet succesvol aangepast");
            }
            else
            {
                MessageBox.Show("Selecteer eerst een useraccount");
            }
        }

        private void linkRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var registerForm = new RegisterUserForm();
            registerForm.ShowDialog();
            lbUsers.Items.Clear();
            lbUsers.Items.AddRange(_logic.AllUsers.Where(user => user.ID != _user.ID).ToArray());
        }
    }
}
