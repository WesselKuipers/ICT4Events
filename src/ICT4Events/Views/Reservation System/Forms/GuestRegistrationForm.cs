using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SharedModels.Logic;
using SharedModels.Models;

namespace ICT4Events.Views.Reservation_System.Forms
{
    public partial class GuestRegistrationForm : Form
    {
        private User _user;

        private Event _event;
        private Location _location;
        private int _locationGuestCount;

        private List<TextBox> _additionalGuests;

        public Guest Guest;

        public GuestRegistrationForm(User user, Event ev)
        {
            InitializeComponent();
            _user = user;
            _event = ev;

            _additionalGuests = new List<TextBox> {txtAdditionalGuest1};

            cmbLocations.DataSource = LogicCollection.LocationLogic.GetLocationsByEvent(ev);

            calEventDate.MinDate = _event.StartDate;
            calEventDate.MaxDate = _event.EndDate;

            calEventDate.SetSelectionRange(_event.StartDate, _event.EndDate);
            calEventDate.MaxSelectionCount = (int)(_event.EndDate.Subtract(_event.StartDate).TotalDays) + 1;
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (_locationGuestCount + 1 > _location.Capacity)
            {
                throw new InvalidEventRegistrationException("De capaciteit van deze locatie is overschreden.");
            }

            // TODO: Registrating new guest to event
            // TODO: Adding multiple guests
        }

        private void cmbLocations_SelectedIndexChanged(object sender, EventArgs e)
        {
            _location = (Location) cmbLocations.SelectedItem;

            _locationGuestCount = LogicCollection.GuestLogic.GetGuestsByLocation(_location);
            lblLocationCapacity.Text = $"{_locationGuestCount} / {_location.Capacity}";
        }

        private void lblNewGuest_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var txtAdditionalGuest = new TextBox();

            tblAdditionalGuests.Controls.Add(new Label{ Text = "Email" });
            tblAdditionalGuests.Controls.Add(txtAdditionalGuest);

            _additionalGuests.Add(txtAdditionalGuest);
        }
    }
}
