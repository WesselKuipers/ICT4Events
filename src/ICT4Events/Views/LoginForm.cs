using System;
using System.Net.NetworkInformation;
using System.Security.Authentication;
using System.Windows.Forms;
using ICT4Events.Views.Accountsystem;
using SharedModels.Data.OracleContexts;
using SharedModels.Debug;
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

        private void LoginForm_Load(object sender, EventArgs e)
        {
            var username = Properties.Settings.Default.Username;
            if (!string.IsNullOrWhiteSpace(username))
            {
                txtUsername.Text = username;
            }

            if (!string.IsNullOrWhiteSpace(txtUsername.Text))
            {
               this.ActiveControl =  txtPassword;
            }
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

            if (!PingHost("192.168.20.221"))
            {
                MessageBox.Show("Kan geen verbinding maken met de database.\r\nBent u ingelogd op het juiste netwerk?");
                return;
            }

            try
            {
                var userLogic = new UserLogic(new UserOracleContext());

                User = userLogic.AuthenticateUser(txtUsername.Text, userLogic.GetHashedPassword(txtPassword.Text));

                Properties.Settings.Default.Username = User.Username;
                Properties.Settings.Default.Save();

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

        public static bool PingHost(string nameOrAddress)
        {
            var pingable = false;
            var pinger = new Ping();
            try
            {
                var reply = pinger.Send(nameOrAddress);
                pingable = reply.Status == IPStatus.Success;
            }
            catch (PingException e)
            {
                Logger.Write(e.Message);
                return false;
            }
            return pingable;
        }
    }
}
