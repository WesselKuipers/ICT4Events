using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SharedModels.Data.ContextInterfaces;
using SharedModels.Data.OracleContexts;
using SharedModels.Logic;
using SharedModels.Models;

namespace ICT4Events.Views.MaterialSystem.Forms
{
    public partial class MaterialReservationSystem : Form
    {
        #region Local Variables

        private readonly Event _event;
        private readonly Guest _guest;

        #endregion


        public MaterialReservationSystem(Event ev, Guest guest)
        {
            InitializeComponent();
            _event = ev;
            _guest = guest;
        }

        private void reserveBtn_Click(object sender, EventArgs e)
        {
            if (lsbUserMaterials.SelectedIndex == -1 || lsbUserMaterials.Items.Count <= 0) return;
            var mat = LogicCollection.MaterialLogic.AddReservation(((Material)lsbUserMaterials.SelectedItem), _guest.ID, dtpStart.Value, dtpEnd.Value);
            MessageBox.Show("Succesfully reserved " + mat.Name + " . It will be available from " + mat.StartDate + " till " + mat.EndDate + " at " + _event.Name);
            UpdateListBox();
        }


        private void UpdateListBox()
        {
            lsbUserMaterials.Items.Clear();
            if (string.IsNullOrEmpty(txtSearch.Text))
            {
                foreach (var material in LogicCollection.MaterialLogic.GetAllByEventAndNonReserved(_event))
                {
                    lsbUserMaterials.Items.Add(material);
                }
            }
            else
            {
                foreach (var material in LogicCollection.MaterialLogic.GetAllByEventAndNonReserved(_event).Where(material => txtSearch.Text == material.Name))
                {
                    lsbUserMaterials.Items.Add(material);
                }
            }
        }

        private void MaterialReservationSystem_Load(object sender, EventArgs e)
        {
            UpdateListBox();
            if (_event.StartDate > DateTime.Now && _event.EndDate < DateTime.Now)
            {
                dtpStart.Value = dtpStart.MinDate = dtpEnd.MinDate = DateTime.Today;
                dtpEnd.Value = dtpEnd.MaxDate = dtpStart.MaxDate = _event.EndDate;
            }
            else
            {
                MessageBox.Show("WARNING: You are accesing an event that has already happened");
                if (_event.StartDate > DateTime.Now && _event.EndDate < DateTime.Now)
                {
                    dtpStart.Value = dtpStart.MinDate = dtpEnd.MinDate = DateTime.Today;
                    dtpEnd.Value = dtpEnd.MaxDate = dtpStart.MaxDate = _event.EndDate;
                }
                else
                {
                    MessageBox.Show("WARNING: You are accesing an event that has already happened");
                    dtpStart.Value = dtpStart.MinDate = dtpEnd.MinDate = _event.StartDate;
                    dtpEnd.Value = dtpEnd.MaxDate = dtpStart.MaxDate = _event.EndDate;
                }
            }
        }

        private void searchTb_TextChanged(object sender, EventArgs e)
        {
            UpdateListBox();
        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            UpdateListBox();
        }

        private void lsbReserved_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}