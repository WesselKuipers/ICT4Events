using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Phidgets;
using Phidgets.Events;
using SharedModels.Data.ContextInterfaces;
using SharedModels.Data.OracleContexts;
using SharedModels.Enums;
using SharedModels.Logic;
using SharedModels.Models;


namespace ICT4Events.Views.MaterialSystem.Forms
{
    public partial class MaterialSystem : Form
    {
        #region Local Variables

        private readonly User _user;
        private readonly Event _event;
        private bool _rfidScanned;
        //private RFID rfid;
        #endregion

        /// <summary>
        /// Constructor of the material system
        /// </summary>
        /// <param name="ev"></param>
        public MaterialSystem(Event ev, User user)
        {
            InitializeComponent();
            _event = ev;
            _user = user;
            _rfidScanned = true;
        }

        #region RFID (Do not delete)
        /*
        private void frmToegang_Load(object sender, EventArgs e)
        {
            rfid = new RFID();
            rfid.Attach += new AttachEventHandler(this.rfid_Attach);
            rfid.Detach += new DetachEventHandler(this.rfid_Detach);
            rfid.Tag += new TagEventHandler(this.rfid_Tag);
            rfid.TagLost += new TagEventHandler(this.rfid_TagLost);
            this.openCmdLine(this.rfid);

        }

        private void rfid_Attach(object sender, AttachEventArgs e)
        {
            RFID attached = (RFID)sender;
            if (this.rfid.outputs.Count > 0)
            {
                this.rfid.Antenna = true;
            }
        }

        private void rfid_Detach(object sender, DetachEventArgs e)
        {
            RFID detached = (RFID)sender;
        }
        private void rfid_Tag(object sender, TagEventArgs e)
        {
            
            string id = tbRFIDIDZoeken.Text;
            bool aanwezig = x.AanwezigheidsStatusupdate(id);
            aanwezig = !aanwezig;
            x.AanwezigheidsUpdate(aanwezig, id);
            tbRFIDIDZoeken.Text = e.Tag;
            x.DatabaseConnect();
            DataTable validatie = x.Check(id);
            DataRow[] datarow1 = validatie.Select("VNAAM = VNAAM");
            foreach (DataRow row in datarow1)
            {
                tbNaam.Text = datarow1[0].ToString();
                tbRekeningNummer.Text = datarow1[6].ToString();
                tbKampeerplaats.Text = datarow1[2].ToString();
                tbTelefoonNummer.Text = datarow1[1].ToString();
                if (datarow1[5].ToString() == "Y")
                {
                    cbBetaald.Checked = true;
                }
                else
                {
                    cbBetaald.Checked = false;
                }
            }

            this.Refresh();
        }

        private void rfid_TagLost(object sender, TagEventArgs e)
        {
            tbRFIDIDZoeken.Text = string.Empty;
            tbNaam.Text = string.Empty;
            tbRekeningNummer.Text = string.Empty;
            tbTelefoonNummer.Text = string.Empty;
            tbKampeerplaats.Text = string.Empty;
            cbBetaald.Checked = false;
        }
        */
        #endregion

        #region Other Functions

        /// <summary>
        /// Checks if a list of textboxes are filled in
        /// </summary>
        /// <param name="textBoxes"></param>
        /// <returns></returns>
        private bool FieldsFilled(List<TextBox> textBoxes)
        {
            var check = true;
            foreach (var tb in textBoxes.Where(tb => string.IsNullOrEmpty(tb.Text)))
            {
                check = false;
            }
            return check;
        }

        /// <summary>
        /// Refreshes the article number and -name
        /// </summary>
        private void UpdateArtNumberArtName()
        {
            if (lsbMaterialStorage.SelectedIndex != -1)
            {
                foreach (
                    var material in
                        LogicCollection.MaterialLogic.GetAllByEvent(_event)
                            .Where(material => material.Name == lsbMaterialStorage.SelectedItem.ToString()))
                {
                    txtMaterialID.Text = material.ID.ToString();
                    txtMaterialName.Text = material.Name;
                }
            }
            else
            {
                txtMaterialID.Text = string.Empty;
                txtMaterialName.Text = string.Empty;
                txtNewMaterialName.Text = string.Empty;
                txtNewMaterialType.Text = string.Empty;
            }
        }

        /// <summary>
        /// Refreshes listboxes and the category dropdownbox
        /// </summary>
        private void UpdateListBoxAndCategory()
        {
            //Refresh user listbox
            if (_rfidScanned)
            {
                lsbUserMaterial.Items.Clear();
                foreach (
                    var material in
                        LogicCollection.GuestLogic.GetGuestsByEvent(_event)
                            .Where(guest => guest.PassID == txtUserNumber.Text)
                            .SelectMany(guest => LogicCollection.MaterialLogic.GetReservedMaterialsByGuest(guest)))
                {
                    lsbUserMaterial.Items.Add(material.Name);
                }
            }

            //Refresh storage listbox
            lsbMaterialStorage.Items.Clear();
            foreach (var material in LogicCollection.MaterialLogic.GetAllByEventAndNonReserved(_event))
            {
                lsbMaterialStorage.Items.Add(material.Name);
            }

            //Refresh categorie combobox
            var savedIndex = cbCategory.SelectedIndex;
            cbCategory.Items.Clear();
            cbCategory.Items.Add("Any");
            foreach (var mt in LogicCollection.MaterialLogic.GetAll())
            {
                cbCategory.Items.Add(mt.Name);
            }
            cbCategory.SelectedIndex = savedIndex;
        }

        /// <summary>
        /// Refreshes listboxes based on category
        /// </summary>
        private void UpdateListBox(string categorie)
        {
            //Refresh user listbox and category
            if (_rfidScanned)
            {
                lsbUserMaterial.Items.Clear();
                foreach (
                    var material in
                        LogicCollection.GuestLogic.GetGuestsByEvent(_event)
                            .Where(guest => guest.PassID == txtUserNumber.Text)
                            .SelectMany(guest => LogicCollection.MaterialLogic.GetReservedMaterialsByGuest(guest)))
                {
                    lsbUserMaterial.Items.Add(material.Name);
                }
            }

            //Refresh storage listbox
            lsbMaterialStorage.Items.Clear();
            foreach (
                var material in
                    LogicCollection.MaterialLogic.GetAllByEventAndNonReserved(_event)
                        .Where(material => material.TypeID == LogicCollection.MaterialLogic.GetByName(categorie).ID))
            {
                lsbMaterialStorage.Items.Add(material.Name);
            }

        }

        /// <summary>
        /// Refreshes listboxes
        /// </summary>
        private void UpdateListBox()
        {
            //Refresh user listbox
            if (_rfidScanned)
            {
                lsbUserMaterial.Items.Clear();
                foreach (
                    var material in
                        LogicCollection.GuestLogic.GetGuestsByEvent(_event)
                            .Where(guest => guest.PassID == txtUserNumber.Text)
                            .SelectMany(guest => LogicCollection.MaterialLogic.GetReservedMaterialsByGuest(guest)))
                {
                    lsbUserMaterial.Items.Add(material.Name);
                }
            }

            //Refresh storage listbox
            lsbMaterialStorage.Items.Clear();
            foreach (var material in LogicCollection.MaterialLogic.GetAllByEventAndNonReserved(_event))
            {
                lsbMaterialStorage.Items.Add(material.Name);
            }
        }
        #endregion

        #region Eventhandlers
        #region Selected Index Changed
        /// <summary>
        /// Index changed of category dropdownbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbCategory.Text == "Any" || cbCategory.Text == "")
            {
                UpdateListBox();
            }
            else
            {
                UpdateListBox(cbCategory.Text);
            }
        }

        /// <summary>
        /// Index changed of material storage listbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lsbMaterialStorage_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateArtNumberArtName();
        }
        #endregion

        #region Click
        /// <summary>
        /// Moves material of a guest back to the storage
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReturn_Click(object sender, EventArgs e)
        {
            var boxes = new List<TextBox> {txtUserNumber, txtUserName};

            if (FieldsFilled(boxes) && lsbUserMaterial.Items.Count > 0 && lsbUserMaterial.SelectedIndex != -1)
            {
                foreach (
                    var material in
                        LogicCollection.MaterialLogic.GetReservedMaterialsByGuest(
                            LogicCollection.GuestLogic.GetByRfid(txtUserNumber.Text))
                            .Where(material => material.Name == lsbUserMaterial.Text)
                            .Where(material => !LogicCollection.MaterialLogic.RemoveReservation(material)))
                {
                    MessageBox.Show("Material unsuccesfully deleted: " + material.Name);
                }
            }
            UpdateListBoxAndCategory();
        }

        /// <summary>
        /// Moves material of the storage back to a guest
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRentMaterial_Click(object sender, EventArgs e)
        {
            //Specify required textboxes
            var boxes = new List<TextBox> {txtUserNumber, txtUserName, txtMaterialID, txtMaterialName};

            if (FieldsFilled(boxes) && lsbMaterialStorage.Items.Count > 0 && lsbMaterialStorage.SelectedIndex != -1)
            {
                foreach (
                    var material in
                        LogicCollection.MaterialLogic.GetAllByEvent(_event)
                            .Where(material => material.ID.ToString() == txtMaterialID.Text))
                {
                    LogicCollection.MaterialLogic.AddReservation(material,
                        LogicCollection.GuestLogic.GetByRfid(txtUserNumber.Text).ID,
                        _event.StartDate, _event.EndDate);
                }
            }
            UpdateListBoxAndCategory();
            UpdateArtNumberArtName();
        }


        /// <summary>
        /// Deletes a material from storage
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRemoveMaterial_Click(object sender, EventArgs e)
        {
            var remove = new List<Material>();
            foreach (
                var material in
                    LogicCollection.MaterialLogic.GetAllByEvent(_event)
                        .Where(
                            material =>
                                txtMaterialID.Text == material.ID.ToString() && txtMaterialName.Text == material.Name))
            {
                remove.Add(material);
                if (lsbMaterialStorage.Items.Count >= 1 && lsbMaterialStorage.SelectedItem != null)
                {
                    lsbMaterialStorage.Items.Remove(lsbMaterialStorage.SelectedItem.ToString());
                }
            }
            foreach (var material in remove)
            {
                MessageBox.Show(LogicCollection.MaterialLogic.Delete(material)
                    ? "Succesfully deleted material"
                    : "Failed to delete material");
                LogicCollection.MaterialLogic.GetAllByEvent(_event).Remove(material);
            }
        }

        /// <summary>
        /// Changes the values of a material in storage
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// werkend
        private void btnMaterialEdit_Click(object sender, EventArgs e)
        {
            var boxes = new List<TextBox> {txtNewMaterialName, txtMaterialID, txtMaterialName};
            if (!FieldsFilled(boxes)) return;
            foreach (var material in LogicCollection.MaterialLogic.GetAllByEvent(_event).Where(material => material.ID.ToString() == txtMaterialID.Text))
            {
                if (!string.IsNullOrEmpty(txtNewMaterialType.Text))
                {

                    LogicCollection.MaterialLogic.Insert(new MaterialType(0, txtNewMaterialType.Text));
                    LogicCollection.MaterialLogic.Update(new Material(material.ID, txtNewMaterialName.Text, material.EventID,
                        LogicCollection.MaterialLogic.GetByName(txtNewMaterialType.Text).ID));
                }
                else
                {
                    LogicCollection.MaterialLogic.Update(new Material(material.ID, txtNewMaterialName.Text, material.EventID,
                        material.TypeID));
                }
            }
            UpdateListBoxAndCategory();
            UpdateArtNumberArtName();
        }

        /*
            Material oldMaterial = new Material();
            Material newMaterial = new Material();
            //var editable = false;

            if (ArtikelnummerTb.Text != "" && ProductNewTb.Text != "")
            {
                foreach (var material in _contextMaterial.GetAllByEvent(_event))
                {
                    if (material.Name == ProductTb.Text && material.ID.ToString() == ArtikelnummerTb.Text)
                    {
                        oldMaterial = material;
                    }
                }

                newMaterial = new Material(0, ProductNewTb.Text, _event.ID, _contextMaterialType.GetByName(TypeNewTb.Text).ID);
                //newMaterial = new Material(int.Parse(ArtikelnummerNewTb.Text), ProductNewTb.Text, TypeNewTb.Text);
            }
            EditMaterial(oldMaterial, newMaterial);
            
        }      
*/
        /// <summary>
        /// Adds a material to storage
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMaterialAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNewMaterialName.Text)) return;

            if (!string.IsNullOrEmpty(txtNewMaterialType.Text))
            {
                var typeAppearsAlready = false;
                foreach (var mt in LogicCollection.MaterialLogic.GetAll().Where(mt => mt.Name == txtNewMaterialType.Text))
                {
                    typeAppearsAlready = true;
                }
                if (!typeAppearsAlready)
                {
                    LogicCollection.MaterialLogic.Insert(new MaterialType(0, txtNewMaterialType.Text));
                    LogicCollection.MaterialLogic.Insert(new Material(0, txtNewMaterialName.Text, _event.ID,
                        LogicCollection.MaterialLogic.GetByName(txtNewMaterialType.Text).ID));
                }
                else
                {
                    LogicCollection.MaterialLogic.Insert(new Material(0, txtNewMaterialName.Text, _event.ID,
                        LogicCollection.MaterialLogic.GetByName(txtNewMaterialType.Text).ID));
                }
            }
            else
            {
                LogicCollection.MaterialLogic.Insert(new Material(0, txtNewMaterialName.Text, _event.ID));
            }
            UpdateListBoxAndCategory();
            UpdateArtNumberArtName();
            /*
            if (!string.IsNullOrEmpty(ProductNewTb.Text))
            {
                if(!string.IsNullOrEmpty(TypeNewTb.Text))
                    AddMaterial(new Material(0, ProductNewTb.Text, _event.ID, _contextMaterialType.GetByName(TypeNewTb.Text).ID));
                else
                    AddMaterial(new Material(0, ProductNewTb.Text, _event.ID, _contextMaterialType.GetByName("Overige").ID));
            }
            */
        }
        #endregion

        /// <summary>
        /// Calls to UpdateListBoxAndCategory() once the form has finished loading
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MaterialSystem_Load(object sender, EventArgs e)
        {
            btnRemoveMaterial.Enabled = btnMaterialAdd.Enabled = _user.Permission == PermissionType.Administrator;
            UpdateListBoxAndCategory();
        }
        #endregion
    }
}
