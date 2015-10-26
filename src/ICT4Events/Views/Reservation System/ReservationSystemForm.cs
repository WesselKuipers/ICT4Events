using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ICT4Events.Views.Reservation_System.Forms;
using SharedModels.Data.OracleContexts;
using SharedModels.Logic;
using SharedModels.Models;

namespace ICT4Events.Views.Reservation_System
{
    public partial class ReservationSystemForm : Form
    {
        private User _user;
        private EventLogic _eventRepo;
        private GuestLogic _guestRepo;
        private List<Event> _events;
        private Guest _guest;

        public ReservationSystemForm(User user)
        {
            InitializeComponent();
            _user = user;
            _eventRepo = new EventLogic(new EventOracleContext());
            _guestRepo = new GuestLogic(new GuestOracleContext());

            _events = _eventRepo.GetAllEvents();

            cmbEvents.DataSource = _events;
            cmbEvents.SelectedIndex = 0;
        }

        private void cmbEvents_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateEventInformation();
        }

        private void UpdateEventInformation()
        {
            var ev = (Event) cmbEvents.SelectedItem;
            _guest = _guestRepo.GetGuestByEvent(ev, _user.ID);

            lblEventName.Text = ev.Name;

            var guestCount = _guestRepo.GetGuestCountByEvent(ev);
            lblEventCapacity.Text = $"{guestCount} / {ev.MaxCapacity}";

            var eventDays = new List<DateTime>();
            for (var date = ev.StartDate; date.Date <= ev.EndDate.Date; date = date.AddDays(1))
            {
                eventDays.Add(date);
            }

            // TODO: Determine if it's desired to have max start and end date set
            calEventDate.MinDate = ev.StartDate;
            calEventDate.MaxDate = ev.EndDate;

            calEventDate.BoldedDates = eventDays.ToArray();
            calEventDate.SetSelectionRange(ev.StartDate, ev.EndDate);
            calEventDate.MaxSelectionCount = (int) (ev.EndDate.Subtract(ev.StartDate).TotalDays) + 1;

            // TODO: Make sure this actually gets saved here
            picEventMap.ImageLocation = $"{Properties.Settings.Default.FTPAddress}/{ev.ID}/{ev.MapPath}";

            if (_guest != null)
            {
                lblGuestStatus.Text = "Ingeschreven, " + (_guest.Paid ? "betaald" : "niet betaald");
                lblGuestStatus.ForeColor = _guest.Paid ? Color.Green : Color.Red;

                btnPayForEvent.Enabled = !_guest.Paid;
                btnRegisterForEvent.Enabled = false;
            }
            else
            {
                lblGuestStatus.Text = "Niet ingeschreven";
                lblGuestStatus.ForeColor = Color.Black;

                btnPayForEvent.Enabled = false;
                btnRegisterForEvent.Enabled = true;
            }
        }

        private void btnRegisterForEvent_Click(object sender, EventArgs e)
        {

        }

        private void btnPayForEvent_Click(object sender, EventArgs e)
        {
            var totalAmount = 0;
            if (new GuestPaymentForm(totalAmount).ShowDialog() == DialogResult.OK)
            {
                _guest.Paid = true;
                _guestRepo.UpdateGuest(_guest);
            }
        }
    }
}
