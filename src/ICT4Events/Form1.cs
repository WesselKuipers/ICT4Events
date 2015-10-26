using System;
using System.Windows.Forms;
using ICT4Events.Views.Accountsystem;
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

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
