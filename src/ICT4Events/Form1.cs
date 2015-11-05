using System;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using ICT4Events.Views;
using ICT4Events.Views.Accountsystem;
using ICT4Events.Views.MaterialSystem.Forms;
using ICT4Events.Views.Reservation_System;
using ICT4Events.Views.SocialSystem.Forms;
using SharedModels.Data.OracleContexts;
using SharedModels.Models;

namespace ICT4Events
{
    public partial class Form1 : Form
    {
        private readonly User _user;
        private readonly Event _ev;
        private readonly Guest _guest;
        private readonly GuestOracleContext _logicGuest;

        public Form1(User user)
        {
            InitializeComponent();
            _logicGuest = new GuestOracleContext();
            _ev = new Event(1, "ICT4Events", new DateTime(2015, 10, 25), new DateTime(2015, 11, 5), "IdontKnowYet", "IdontKnowYet", 100);
            _user = user;
            _guest = _logicGuest.GetById(user.ID);
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
		
        private void btnLogOut_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Restart();
        }

        private void btSocial_Click(object sender, EventArgs e)
        {
            new SocialMediaSystemForm(_user, _ev).ShowDialog();
        }

        private void btMaterial_Click(object sender, EventArgs e)
        {
            new MaterialSystem(_ev).ShowDialog();
        }
    }
}
