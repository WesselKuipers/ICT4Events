using System;
using System.Windows.Forms;
using SharedModels.Enums;
using SharedModels.Logic;
using SharedModels.Models;

namespace ICT4Events.Views.Accountsystem.Controls
{
    public partial class UcEditUser : UserControl
    {
        private readonly User _user;
        private readonly UserLogic _logic;

        public UcEditUser(User user)
        {
            InitializeComponent();
            _user = user;
            _logic = new UserLogic();
        }

        private void ucEditUser_Load(object sender, EventArgs e)
        {
            // load Country's to combobox
            foreach (var country in Enum.GetValues(typeof(Country)))
            {
                cbCountry.Items.Add(country);
            }

            // load current values
            txtName.Text = _user.Name;
            txtSurname.Text = _user.Surname;
            cbCountry.Text = _user.Country.ToString();
            txtCity.Text = _user.City;
            txtAddress.Text = _user.Address;
            txtPostal.Text = _user.Postal;
            txtPhone.Text = _user.Telephone;
        }

        private void btnUpdateUser_Click(object sender, EventArgs e)
        {
            // set all user fields to (updated) values
            _user.Name = txtName.Text;
            _user.Surname = txtSurname.Text;
            _user.Country = (Country)cbCountry.SelectedItem;
            _user.City = txtCity.Text;
            _user.Address = txtAddress.Text;
            _user.Postal = txtPostal.Text;
            _user.Telephone = txtPhone.Text;

            // try to update user and show appropriate message
            MessageBox.Show(_logic.UpdateUser(_user)
                ? "Account is succesvol gewijzigd"
                : "Er is iets fout gegaan. Account is niet gewijzigd");
        }
    }
}
