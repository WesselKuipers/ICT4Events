using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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
            var guest = _guestRepo.GetGuestByEvent(ev, _user.ID);

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
        }
    }
}
