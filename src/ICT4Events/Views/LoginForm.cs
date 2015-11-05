using System;
using System.Security.Authentication;
using System.Windows.Forms;
using ICT4Events.Views.Accountsystem;
using SharedModels.Data.OracleContexts;
using SharedModels.Logic;
using SharedModels.Models;

namespace ICT4Events.Views
{
    public partial class LoginForm : Form
    {
        public User User;
        private bool _alreadyFocused;

        public LoginForm()
        {
            InitializeComponent();
            _alreadyFocused = false;

            txtPassword.GotFocus += TxtPassword_GotFocus;
            txtPassword.MouseUp += TxtPassword_MouseUp;
            txtPassword.Leave += TxtPassword_Leave;
        }

        private void TxtPassword_Leave(object sender, EventArgs e)
        {
            _alreadyFocused = false;
            
        }

        private void TxtPassword_MouseUp(object sender, MouseEventArgs e)
        {
            if (_alreadyFocused || txtPassword.SelectionLength != 0) return;
            _alreadyFocused = true;
            txtPassword.SelectAll();
        }

        private void TxtPassword_GotFocus(object sender, EventArgs e)
        {
            // Select all text only if the mouse isn't down.
            // This makes tabbing to the textbox give focus.
            if (MouseButtons != MouseButtons.None) return;
            txtPassword.SelectAll();
            _alreadyFocused = true;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                MessageBox.Show("Gebruikersnaam is niet ingevuld!");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Wachtwoord is niet ingevuld!");
                return;
            }

            try
            {
                var userLogic = new UserLogic(new UserOracleContext());

                User = userLogic.AuthenticateUser(txtUsername.Text, userLogic.GetHashedPassword(txtPassword.Text));
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (InvalidCredentialException ex)
            {
                MessageBox.Show(ex.Message);
                txtPassword.Text = string.Empty;
            }
        }

        private void linkRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var registerForm = new RegisterUserForm();
            registerForm.ShowDialog();
        }
    }
}
