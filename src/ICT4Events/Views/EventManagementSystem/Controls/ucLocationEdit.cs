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
    public partial class ucLocationEdit : UserControl
    {
        private Event _event;

        public ucLocationEdit(Event ev)
        {
            InitializeComponent();
            _event = ev;

            var locations = LogicCollection.LocationLogic.GetLocationsByEvent(_event);
            lsbLocations.Items.AddRange(locations.ToArray());

            lsbLocations.SelectedIndex = 0;
        }

        private void btnAddLocation_Click(object sender, EventArgs e)
        {
            if (!CheckRequiredFields()) return;

            var location =
                LogicCollection.LocationLogic.InsertLocation(new Location(0, _event.ID, txtLocationName.Text,
                    (int) numLocationCapacity.Value, numLocationPrice.Value, new Point(0, 0)));

            if (location != null)
            {
                lsbLocations.Items.Add(location);
                lsbLocations.SelectedItem = Location;
            }
            else
            {
                MessageBox.Show("Er is iets misgegaan bij het toeveogen van deze locatie");
            }
        }

        private void btnEditLocation_Click(object sender, EventArgs e)
        {
            if (!CheckRequiredFields()) return;

            var location = (Location)lsbLocations.SelectedItem;

            location.Name = txtLocationName.Text;
            location.Capacity = (int) numLocationCapacity.Value;
            location.Price = numLocationPrice.Value;

            if (!LogicCollection.LocationLogic.UpdateLocation(location))
            {
                MessageBox.Show("Er is iets misgegaan bij het aanpassen van deze locatie");
            }
            else
            {
                lsbLocations.Items.Remove(location);
                lsbLocations.Items.Add(location);
                lsbLocations.SelectedItem = location;
            }
        }

        private void btnDeleteLocation_Click(object sender, EventArgs e)
        {
            var location = (Location) lsbLocations.SelectedItem;

            if (!LogicCollection.LocationLogic.DeleteLocation(location))
            {
                MessageBox.Show("Het is niet toegestaan om deze locatie te verwijderen");
            }
            else
            {
                lsbLocations.Items.Remove(location);
            }
        }

        private void lsbLocations_SelectedIndexChanged(object sender, EventArgs e)
        {
            var location = (Location) lsbLocations.SelectedItem;

            if (location == null) return;

            txtLocationName.Text = location.Name;
            numLocationCapacity.Value = location.Capacity;
            numLocationPrice.Value = location.Price;
        }

        private bool CheckRequiredFields()
        {
            return !string.IsNullOrWhiteSpace(txtLocationName.Text) &&
                   numLocationCapacity.Value > 0;
        }
    }
}
