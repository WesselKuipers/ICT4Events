using System;
using System.Linq;
using System.Windows.Forms;
using SharedModels.Enums;
using SharedModels.Logic;
using SharedModels.Models;

namespace ICT4Events.Views.Accountsystem.Controls
{
    public partial class UcDeleteUser : UserControl
    {
        private readonly UserLogic _logic;

        public UcDeleteUser()
        {
            InitializeComponent();
            _logic = new UserLogic();
        }

        private void ucDeleteUser_Load(object sender, EventArgs e)
        {
            // add all users that are not administrators to the listbox
            foreach (var user in _logic.AllUsers.Where(user => user.Permission != PermissionType.Administrator))
            {
                lbUsers.Items.Add(user);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (AccountIsSelected())
            {
                var reply = MessageBox.Show(
                    "Weet je zeker dat je dit account wilt verwijderen?", 
                    "Zeker weten?",
                    MessageBoxButtons.YesNo);

                if (reply == DialogResult.Yes)
                {
                    if (_logic.DeleteUser(lbUsers.SelectedItem as User))
                    {
                        lbUsers.Items.Remove(lbUsers.SelectedItem);
                    }
                    else
                    {
                        MessageBox.Show("Er is iets misgegaan, account is niet verwijderd");
                    }
                }
            }
            else
            {
                MessageBox.Show("Selecteer eerst een account om te verwijderen");
            }
        }

        private bool AccountIsSelected()
        {
            // if nothing is selected or selected object is not a user return false
            return lbUsers.SelectedItem is User;
        }
    }
}
