using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ICT4Events.Views.Accountsystem;
using ICT4Events.Views.Reservation_System;
using SharedModels.Enums;
using SharedModels.Models;

namespace ICT4Events
{
    public partial class Form1 : Form
    {
        private User _user;

        public Form1(User user)
        {
            InitializeComponent();
            _user = user;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new AccountSystemForm(
                new User(
                    1,
                    "test@test.nl",
                    "test1",
                    "test2",
                    "test3",
                    Country.Luxemburg,
                    "test4",
                    "1234AB",
                    "test 23",
                    "0612345678",
                    DateTime.Now,
                    PermissionType.Administrator
                )
            ).ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new ReservationSystemForm(_user).ShowDialog();
        }
    }
}
