using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SharedModels.Exceptions;
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

        public Guest Guest;

        public GuestRegistrationForm(User user, Event ev)
        {
            InitializeComponent();
            _user = user;
            _event = ev;

            lblEventName.Text = ev.Name;
            cmbLocations.DataSource = LogicCollection.LocationLogic.GetLocationsByEvent(ev);

            calEventDate.MinDate = _event.StartDate;
            calEventDate.MaxDate = _event.EndDate;

            calEventDate.SetSelectionRange(_event.StartDate, _event.EndDate);
            calEventDate.MaxSelectionCount = (int)(_event.EndDate.Subtract(_event.StartDate).TotalDays) + 1;
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                RegisterUsersForEvent();
            }
            catch (InvalidEventRegistrationException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmbLocations_SelectedIndexChanged(object sender, EventArgs e)
        {
            _location = (Location) cmbLocations.SelectedItem;

            _locationGuestCount = LogicCollection.GuestLogic.GetGuestCountByLocation(_location);
            lblLocationCapacity.Text = $"{_locationGuestCount} / {_location.Capacity}";
        }

        private void RegisterUsersForEvent()
        {
            if (_locationGuestCount + 1 > _location.Capacity)
            {
                throw new InvalidEventRegistrationException("De capaciteit van deze locatie is overschreden. Selecteer een andere locatie.");
            }

            var additionalGuestUsernames = new List<string>();
            foreach (var txt in tblAdditionalGuests.Controls.OfType<TextBox>().Where(txt => !string.IsNullOrWhiteSpace(txt.Text)))
            {
                if (User.IsValidEmail(txt.Text))
                {
                    additionalGuestUsernames.Add(txt.Text);
                }
                else
                {
                    MessageBox.Show(
                        $"Invalide emailadres gevonden in lijst van extra personen\r\nEmailadres: {txt.Text}");
                    return;
                }
            }

            if (_locationGuestCount + additionalGuestUsernames.Count + 1 > _location.Capacity)
            {
                throw new InvalidEventRegistrationException("De capaciteit van deze locatie is overschreden. Maak uw groep kleiner of selecteer een andere locatie.");
            }

            var additionalGuests = LogicCollection.GuestLogic.RegisterUsersForEvent(additionalGuestUsernames, _event,
                _location, calEventDate.SelectionStart, calEventDate.SelectionEnd, _user.ID);

            var guest = LogicCollection.GuestLogic.RegisterUserForEvent(_user, _event, _location,
                calEventDate.SelectionStart, calEventDate.SelectionEnd);

            Guest = guest;

            if (MessageBox.Show("Wilt u nu betalen?", "Betalingsverzoek", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                var totalAmount = _location.Price * (1 + additionalGuests.Count);

                if (new GuestPaymentForm(totalAmount).ShowDialog() == DialogResult.OK)
                {
                    Guest.Paid = true;
                    LogicCollection.GuestLogic.UpdateGuest(Guest);
                    foreach (var g in additionalGuests)
                    {
                        g.Paid = true;
                        LogicCollection.GuestLogic.UpdateGuest(g);
                    }
                }
            }

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
