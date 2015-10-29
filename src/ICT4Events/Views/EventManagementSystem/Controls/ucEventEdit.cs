using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SharedModels.Logic;
using SharedModels.Models;

namespace ICT4Events.Views.EventManagementSystem.Controls
{
    public partial class ucEventEdit : UserControl
    {
        private Event _ev;

        public event EventHandler EventSuccessfullyModified;

        public ucEventEdit(Event ev = null)
        {
            InitializeComponent();
            _ev = ev;

            btnUpdateEvent.Text = _ev == null ? "Evenement toevoegen" : "Evenement wijzigen";

            if (_ev == null) return;

            txtName.Text = _ev.Name;
            txtLocation.Text = _ev.Location;
            numCapacity.Value = _ev.MaxCapacity;
            dtpStartDate.Value = _ev.StartDate;
            dtpEndDate.Value = _ev.EndDate;
        }

        private void btnUpdateEvent_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Naam mag niet leeg zijn");
                return;
            }

            if (dtpStartDate.Value >= dtpEndDate.Value)
            {
                MessageBox.Show("Einddatum moet later zijn dan de startdatum");
                return;
            }

            if (_ev != null)
            {
                var guestCount = LogicCollection.GuestLogic.GetGuestCountByEvent(_ev);
                if (numCapacity.Value < guestCount)
                {
                    MessageBox.Show("De capaciteit van evenement is minder dan het huidige aantal ingeschreven gasten");
                    return;
                }

                _ev.Name = txtName.Text;
                _ev.Location = txtLocation.Text;
                _ev.StartDate = dtpStartDate.Value;
                _ev.EndDate = dtpEndDate.Value;
                _ev.MaxCapacity = (int) numCapacity.Value;

                if (LogicCollection.EventLogic.UpdateEvent(_ev))
                {
                    OnEventSuccessfullyModified();
                };
            }
            else
            {
                _ev =
                    LogicCollection.EventLogic.AddEvent(new Event(0,
                        txtName.Text,
                        dtpStartDate.Value,
                        dtpEndDate.Value,
                        txtLocation.Text,
                        maxCap: (int) numCapacity.Value
                        ));
                OnEventSuccessfullyModified();
            }
        }

        protected virtual void OnEventSuccessfullyModified()
        {
            EventSuccessfullyModified?.Invoke(this, EventArgs.Empty);
        }
    }
}
