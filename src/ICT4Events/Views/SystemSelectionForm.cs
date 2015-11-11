using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using ICT4Events.Views.Accountsystem;
using ICT4Events.Views.EntranceControlSystem.Forms;
using ICT4Events.Views.EventManagementSystem;
using ICT4Events.Views.MaterialSystem.Forms;
using ICT4Events.Views.Reservation_System;
using ICT4Events.Views.SocialSystem.Forms;
using SharedModels.Enums;
using SharedModels.Logic;
using SharedModels.Models;

namespace ICT4Events.Views
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
            var btnEntraceControlSystem = new Button { Text = "Toegangscontrole", Dock = DockStyle.Fill };
            var btnMaterialSystem = new Button { Text = "Materiaal Verhuur", Dock = DockStyle.Fill};

            if (_user.Permission == PermissionType.User)
            {
                // Systems available for regular users
                var btnReservationSytem = new Button { Text = "Inschrijven voor evenementen", Dock = DockStyle.Fill };
                btnReservationSytem.Click += OpenReservationSystem;

                btnSocialMediaSystem.Click += OpenSocialMediaUser;

                btnMaterialSystem.Text = "Materiaal Reserveren";
                btnMaterialSystem.Click += OpenMaterialReservation;

                tblSystemButtons.Controls.Add(btnSocialMediaSystem);
                tblSystemButtons.Controls.Add(btnReservationSytem);
                tblSystemButtons.Controls.Add(btnAccountManagementSystem);
                tblSystemButtons.Controls.Add(btnMaterialSystem);

            }
            if (_user.Permission == PermissionType.Employee || _user.Permission == PermissionType.Administrator)
            {
                // Systems only for employees
                btnSocialMediaSystem.Click += OpenSocialMediaEmployee;

                tblSystemButtons.Controls.Add(btnSocialMediaSystem);
                tblSystemButtons.Controls.Add(btnAccountManagementSystem);

                btnMaterialSystem.Click += OpenMaterialManagement;
                tblSystemButtons.Controls.Add(btnMaterialSystem);

                var phidgetInstalled = CheckLibrary("phidget21.dll");
                if (!phidgetInstalled)
                {
                    btnMaterialSystem.Enabled = false;
                    btnEntraceControlSystem.Enabled = false;
                    MessageBox.Show("Phidget RFID driver is niet geïnstalleerd.\r\nMateriaalverhuursysteem en Toegangscontrolesysteem zijn uitgeschakeld.");
                }

                btnEntraceControlSystem.Click += OpenEntranceControl;

                tblSystemButtons.Controls.Add(btnEntraceControlSystem);
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

        private void OpenMaterialReservation(object sender, EventArgs e)
        {
            var eventGuest = SelectEvent();
            var ev = eventGuest.Key;
            var guest = eventGuest.Value;
            if (ev == null || guest == null) { return; }

            new MaterialReservationSystem(ev, guest).ShowDialog();
        }

        private void OpenMaterialManagement(object sender, EventArgs e)
        {
            var ev = SelectEvent(LogicCollection.EventLogic.GetAllEvents());
            if (ev == null) { return; }

            new MaterialSystem.Forms.MaterialSystem(ev, _user).ShowDialog();
        }

        private void OpenEntranceControl(object sender, EventArgs e)
        {
            var ev = SelectEvent(LogicCollection.EventLogic.GetAllEvents());
            if (ev == null) { return; }

            new EntranceControl(ev).ShowDialog();
        }

        private void OpenSocialMediaUser(object sender, EventArgs e)
        {
            var eventGuest = SelectEvent();
            var ev = eventGuest.Key;
            var guest = eventGuest.Value;

            if (ev == null || guest == null) return;
           
            new SocialMediaSystemForm(guest, ev).ShowDialog();
        }

        private void OpenSocialMediaEmployee(object sender, EventArgs e)
        {
            var ev = SelectEvent(LogicCollection.EventLogic.GetAllEvents());
            if (ev == null) { return; }

            new SocialMediaSystemForm(_user, ev).ShowDialog();
        }

        /// <summary>
        /// Opens a form in which an event can be chosen
        /// </summary>
        /// <param name="events">The list of events to choose from</param>
        /// <returns>The chosen event</returns>
        private Event SelectEvent(List<Event> events)
        {
            Event result = null;

            var form = new EventSelectionForm(events);
            if (form.ShowDialog() == DialogResult.OK)
            {
                result = form.Event;
            }

            return result;
        }

        /// <summary>
        /// Determines whether the currently logged in user is participating in any events and allows them to choose it if there is more than one active
        /// </summary>
        /// <returns>Selected event</returns>
        private KeyValuePair<Event, Guest> SelectEvent()
        {
            Event ev;
            Guest guest;

            //var activeEvents = LogicCollection.EventLogic.GetAllEvents().Where(x => x.StartDate >= DateTime.Now && x.EndDate < DateTime.Now).ToList();
            var activeEvents = LogicCollection.EventLogic.GetAllEvents();
            var guests = LogicCollection.GuestLogic.GetGuestsByUser(_user);

            if (!activeEvents.Any() || !guests.Any())
            {
                MessageBox.Show("Er zijn geen actieve evenementen gevonden");
                return default(KeyValuePair<Event, Guest>);
            }

            // If user is a guest in multiple active events..
            if (guests.Count > 1)
            {
                var selectableEvents = activeEvents.Where(x => guests.Select(y => y.EventID).Contains(x.ID)).ToList();
                ev = SelectEvent(selectableEvents);
            }
            else
            {
                ev = activeEvents.First();
            }

            guest = guests.First(x => x.EventID == ev.ID);

            return new KeyValuePair<Event, Guest>(ev, guest);
        }

        [DllImport("kernel32", SetLastError = true)]
        static extern IntPtr LoadLibrary(string lpFileName);

        /// <summary>
        /// Checks if a dll library exists on the machine
        /// </summary>
        /// <param name="fileName">Filename of the library</param>
        /// <returns>True if the library exists</returns>
        static bool CheckLibrary(string fileName)
        {
            return !(LoadLibrary(fileName) == IntPtr.Zero);
        }
    }
}
