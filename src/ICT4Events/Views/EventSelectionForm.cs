using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SharedModels.Models;

namespace ICT4Events.Views
{
    public partial class EventSelectionForm : Form
    {
        public Event Event;

        public EventSelectionForm(List<Event> events)
        {
            InitializeComponent();
            cmbEvents.DataSource = events;
            cmbEvents.SelectedIndex = 0;
        }

        private void btnContinue_Click(object sender, EventArgs e)
        {
            Event = (Event) cmbEvents.SelectedItem;
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
