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
using SharedModels.Models;

namespace ICT4Events.Views.MaterialSystem.Forms
{
    public partial class MaterialReservationSystem : Form
    {
        #region Local Variables

        private readonly Event _event;
        private readonly Guest _guest;
        private readonly IGuestContext _contextGuest;
        private readonly IMaterialContext _contextMaterial;
        private readonly IMaterialTypeContext _contextMaterialType;

        #endregion


        public MaterialReservationSystem(Event ev, Guest guest)
        {
            InitializeComponent();
            _event = ev;
            _guest = guest;
            _contextGuest = new GuestOracleContext();
            _contextMaterial = new MaterialOracleContext();
            _contextMaterialType = new MaterialTypeOracleContext();
        }

        private void reserveBtn_Click(object sender, EventArgs e)
        {
            if (MaterialUserLB.SelectedIndex != -1 && MaterialUserLB.Items.Count > 0)
            {
                foreach (var material in _contextMaterial.GetAllByEventAndNonReserved(_event))
                {
                    if (material.Name == MaterialUserLB.SelectedItem.ToString())
                    {
                        _contextMaterial.AddReservation(material, _guest.ID, _event.StartDate, _event.EndDate);
                    }
                }
                UpdateListBox();
            }

        }


        private void UpdateListBox()
        {
            MaterialUserLB.Items.Clear();
            if (string.IsNullOrEmpty(searchTb.Text))
            {
                foreach (var material in _contextMaterial.GetAllByEventAndNonReserved(_event))
                {
                    MaterialUserLB.Items.Add(material.Name);
                }
            }
            else
            {
                foreach (var material in _contextMaterial.GetAllByEventAndNonReserved(_event))
                {
                    if(searchTb.Text == material.Name)
                        MaterialUserLB.Items.Add(material.Name);
                }
            }
        }

        private void MaterialReservationSystem_Load(object sender, EventArgs e)
        {
            UpdateListBox();
        }

        private void searchTb_TextChanged(object sender, EventArgs e)
        {
            UpdateListBox();
        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            UpdateListBox();
        }
    }
}