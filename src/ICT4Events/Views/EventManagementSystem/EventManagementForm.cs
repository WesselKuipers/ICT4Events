using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ICT4Events.Views.EventManagementSystem.Controls;
using SharedModels.Logic;
using SharedModels.Models;

namespace ICT4Events.Views.EventManagementSystem
{
    public partial class EventManagementForm : Form
    {
        public List<Event> EventList;

        public EventManagementForm()
        {
            InitializeComponent();

            EventList = LogicCollection.EventLogic.GetAllEvents();
            RefreshEventList();

            cmbEvents.SelectedIndex = 0;

            var eventAddControl = new ucEventEdit();
            eventAddControl.EventSuccessfullyModified += Event_Successfully_Modified;

            tabAddEvent.Controls.Add(eventAddControl);
        }

        private void cmbEvents_SelectedIndexChanged(object sender, EventArgs e)
        {
            tabEditEvent.Controls.Clear();

            var eventEditControl = new ucEventEdit((Event) cmbEvents.SelectedItem);
            eventEditControl.EventSuccessfullyModified += Event_Successfully_Modified;

            tabEditEvent.Controls.Add(eventEditControl);
        }

        private void Event_Successfully_Modified(object sender, EventArgs e)
        {
            var selectedIndex = cmbEvents.SelectedIndex;

            RefreshEventList();

            cmbEvents.SelectedIndex = selectedIndex;
        }

        private void RefreshEventList()
        {
            EventList = LogicCollection.EventLogic.GetAllEvents();
            cmbEvents.Items.Clear();
            cmbEvents.Items.AddRange(EventList.ToArray());
        }

    }
}
