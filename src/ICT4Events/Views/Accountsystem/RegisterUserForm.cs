using System;
using System.Windows.Forms;
using SharedModels.Enums;
using SharedModels.Logic;
using SharedModels.Models;

namespace ICT4Events.Views.Accountsystem
{
    public partial class RegisterUserForm : Form
    {
        private readonly UserLogic _logic;

        public RegisterUserForm()
        {
            InitializeComponent();
            _logic = new UserLogic();
        }

        private void RegisterUserForm_Load(object sender, EventArgs e)
        {
            foreach (var permtype in Enum.GetValues(typeof(Country)))
            {
                cbCountry.Items.Add(permtype);
            }

            cbCountry.SelectedItem = Country.Nederland;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (AreNeededFieldsFilled())
            {
                var newUser = _logic.RegisterUser(
                    new User(
                        0,
                        txtEmail.Text,
                        _logic.CheckAndHashPassword(txtPass1.Text, txtPass2.Text),
                        txtName.Text,
                        txtSurname.Text,
                        (Country) cbCountry.SelectedItem,
                        txtCity.Text,
                        txtPostal.Text,
                        txtAddress.Text,
                        txtPhone.Text
                    )
                );

                if (newUser != null)
                {
                    MessageBox.Show("Succesvol geregistreerd!");
                    Close();
                }
            }
            else
            {
                MessageBox.Show("Vul op zijn minst een emailadres, een naam en een wachtwoord in.");
            }
        }

        private bool AreNeededFieldsFilled()
        {
            return 
                !string.IsNullOrWhiteSpace(txtEmail.Text) ||
                !string.IsNullOrWhiteSpace(txtName.Text) ||
                !string.IsNullOrWhiteSpace(txtPass1.Text) ||
                !string.IsNullOrWhiteSpace(txtPass2.Text);
        }
    }
}
