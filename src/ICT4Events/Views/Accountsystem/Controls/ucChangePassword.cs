using System;
using System.Windows.Forms;
using SharedModels.Exceptions;
using SharedModels.Logic;
using SharedModels.Models;

namespace ICT4Events.Views.Accountsystem.Controls
{
    public partial class UcChangePassword : UserControl
    {
        private readonly User _user;
        private readonly UserLogic _logic;

        public UcChangePassword(User user)
        {
            InitializeComponent();
            _user = user;
            _logic = new UserLogic();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (StringIsEmpty())
            {
                MessageBox.Show("Vul eerst alle velden in");
            }
            else
            {
                try
                {
                    MessageBox.Show(_logic.SetNewPassword(_user, txtOld.Text, txtNew1.Text, txtNew2.Text)
                        ? "Wachtwoord is aangepast"
                        : "Wachtwoord is niet aangepast, er is iets misgegaan");
                        txtOld.Text = string.Empty;
                        txtNew1.Text = string.Empty;
                        txtNew2.Text = string.Empty;
                }
                catch (PasswordsDontMatchException x)
                {
                    MessageBox.Show(x.Message);
                }
                
            }
        }

        private bool StringIsEmpty()
        {
            return string.IsNullOrWhiteSpace(txtOld.Text) ||
                string.IsNullOrWhiteSpace(txtNew1.Text) ||
                string.IsNullOrWhiteSpace(txtNew2.Text);
        }
    }
}
