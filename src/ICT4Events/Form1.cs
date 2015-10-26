using System;
<<<<<<< HEAD
=======
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
>>>>>>> 636800bdd72b2d3ada8c224321d9267ef64c2ab2
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using ICT4Events.Views.Accountsystem;
<<<<<<< HEAD
=======
using ICT4Events.Views.Reservation_System;
using SharedModels.Enums;
>>>>>>> 636800bdd72b2d3ada8c224321d9267ef64c2ab2
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
            new AccountSystemForm(_user).ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new ReservationSystemForm(_user).ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
