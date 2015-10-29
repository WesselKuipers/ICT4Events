using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using ICT4Events.Views;
using ICT4Events.Views.Accountsystem;
using ICT4Events.Views.EventManagementSystem;
using ICT4Events.Views.Reservation_System;
using ICT4Events.Views.SocialSystem.Forms;
using SharedModels.Enums;
using SharedModels.Logic;
using SharedModels.Models;

namespace ICT4Events
{
    public partial class SystemSelectionForm : Form
    {
        private readonly User _user;

        public SystemSelectionForm(User user)
        {
            InitializeComponent();
            _user = user;

            var btnAccountManagementSystem = new Button { Text = "Accountgegevens aanpassen", Dock = DockStyle.Fill};
            btnAccountManagementSystem.Click += OpenAccountManagement;

            var btnSocialMediaSystem = new Button {Text = "Tijdlijn bekijken", Dock = DockStyle.Fill };

            if (_user.Permission == PermissionType.User)
            {
                // Systems available for regular users

                var btnReservationSytem = new Button { Text = "Inschrijven voor evenementen", Dock = DockStyle.Fill };
                btnReservationSytem.Click += OpenReservationSystem;

                btnSocialMediaSystem.Click += OpenSocialMediaUser;

                tblSystemButtons.Controls.Add(btnSocialMediaSystem);
                tblSystemButtons.Controls.Add(btnReservationSytem);
                tblSystemButtons.Controls.Add(btnAccountManagementSystem);

            }
            if (_user.Permission == PermissionType.Employee || _user.Permission == PermissionType.Administrator)
            {
                // Systems only for employees

                btnSocialMediaSystem.Click += OpenSocialMediaEmployee;

                tblSystemButtons.Controls.Add(btnSocialMediaSystem);
                tblSystemButtons.Controls.Add(btnAccountManagementSystem);
            }
            if (_user.Permission == PermissionType.Administrator)
            {
                // Systems only for administrators
                var btnEventManagementSystem = new Button { Text = "Evenementbeheer", Dock = DockStyle.Fill };
                btnEventManagementSystem.Click += OpenEventManagement;

                tblSystemButtons.Controls.Add(btnEventManagementSystem);
            }

        }

        private void OpenAccountManagement(object sender, EventArgs e)
        {
            new AccountSystemForm(_user).ShowDialog();
        }

        private void OpenReservationSystem(object sender, EventArgs e)
        {
            new ReservationSystemForm(_user).ShowDialog();
        }
		
        private void btnLogOut_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void OpenEventManagement(object sender, EventArgs e)
        {
            new EventManagementForm().ShowDialog();
        }

        private void OpenSocialMediaUser(object sender, EventArgs e)
        {
            Event ev;
            Guest guest;

            //var activeEvents = LogicCollection.EventLogic.GetAllEvents().Where(x => x.StartDate >= DateTime.Now && x.EndDate < DateTime.Now).ToList();
            var activeEvents = LogicCollection.EventLogic.GetAllEvents();
            var guests = LogicCollection.GuestLogic.GetGuestsByUser(_user);

            if (!activeEvents.Any() || !guests.Any())
            {
                MessageBox.Show("Er zijn geen actieve evenementen gevonden");
                return;
            };

            // If user is a guest in multiple active events..
            if (guests.Count > 1)
            {
                var selectableEvents = activeEvents.Where(x => guests.Select(y => y.EventID).Contains(x.ID)).ToList();

                var form = new EventSelectionForm(selectableEvents);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    ev = form.Event;
                }
                else
                {
                    return;
                }
            }
            else
            {
                ev = activeEvents.First();
            }
            guest = guests.First(x => x.EventID == ev.ID);
            new SocialMediaSystemForm(guest, ev).ShowDialog();
        }

        private void OpenSocialMediaEmployee(object sender, EventArgs e)
        {
            Event ev;

            var events = LogicCollection.EventLogic.GetAllEvents();

            var form = new EventSelectionForm(events);
            if (form.ShowDialog() == DialogResult.OK)
            {
                ev = form.Event;
            }
            else
            {
                return;
            }

            new SocialMediaSystemForm(_user, ev).ShowDialog();
        }
    }
}
