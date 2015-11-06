using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Phidgets;
using Phidgets.Events;
using SharedModels.Data.ContextInterfaces;
using SharedModels.Data.OracleContexts;
using SharedModels.Logic;
using SharedModels.Models;


namespace ICT4Events.Views.MaterialSystem.Forms
{
    public partial class MaterialSystem : Form
    {
        #region Local Variables
        private readonly Event _event;
        private bool _rfidScanned;
        //private RFID rfid;
        #endregion

        /// <summary>
        /// Constructor of the material system
        /// </summary>
        /// <param name="ev"></param>
        public MaterialSystem(Event ev)
        {
            InitializeComponent();
            _event = ev;

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
        /// <param name="TextBoxes"></param>
        /// <returns></returns>
        private bool FieldsFilled(List<TextBox> TextBoxes)
        {
            var Check = true;
            foreach (var tb in TextBoxes)
            {
                if (string.IsNullOrEmpty(tb.Text))
                    Check = false;
            }
            return Check;
        }

        /// <summary>
        /// Refreshes the article number and -name
        /// </summary>
        private void UpdateArtNumberArtName()
        {
            if (MaterialStorageLB.SelectedIndex != -1)
            {
                foreach (var material in LogicCollection.MaterialLogic.GetAllByEvent(_event))
                {
                    if (material.Name == MaterialStorageLB.SelectedItem.ToString())
                    {
                        ArtikelnummerTb.Text = material.ID.ToString();
                        ProductTb.Text = material.Name;
                    }
                }
            }
            else
            {
                ArtikelnummerTb.Text = "";
                ProductTb.Text = "";
                ProductNewTb.Text = "";
                TypeNewTb.Text = "";
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

                MaterialUserLB.Items.Clear();
                foreach (var guest in LogicCollection.GuestLogic.GetGuestsByEvent(_event))
                {
                    if (guest.PassID == GebruikersNummerTb.Text)
                    {
                        foreach (var material in LogicCollection.MaterialLogic.GetReservedMaterialsByGuest(guest))
                        {
                            MaterialUserLB.Items.Add(material.Name);
                        }
                    }
                }
            }

            //Refresh storage listbox
            MaterialStorageLB.Items.Clear();
            foreach (var material in LogicCollection.MaterialLogic.GetAllByEventAndNonReserved(_event))
            {
                MaterialStorageLB.Items.Add(material.Name);
            }

            //Refresh categorie combobox
            var savedIndex = CategorieCb.SelectedIndex;
            CategorieCb.Items.Clear();
            CategorieCb.Items.Add("Any");
            foreach (var mt in LogicCollection.MaterialLogic.GetAll())
            {
                CategorieCb.Items.Add(mt.Name);
            }
            CategorieCb.SelectedIndex = savedIndex;
        }

        /// <summary>
        /// Refreshes listboxes based on category
        /// </summary>
        private void UpdateListBox(string categorie)
        {
            //Refresh user listbox and category
            if (_rfidScanned)
            {

                MaterialUserLB.Items.Clear();
                foreach (var guest in LogicCollection.GuestLogic.GetGuestsByEvent(_event))
                {
                    if (guest.PassID == GebruikersNummerTb.Text)
                    {
                        foreach (var material in LogicCollection.MaterialLogic.GetReservedMaterialsByGuest(guest))
                        {
                            MaterialUserLB.Items.Add(material.Name);
                        }
                    }
                }
            }

            //Refresh storage listbox
            MaterialStorageLB.Items.Clear();
            foreach (var material in LogicCollection.MaterialLogic.GetAllByEventAndNonReserved(_event))
            {
                if(material.TypeID == LogicCollection.MaterialLogic.GetByName(categorie).ID)
                    MaterialStorageLB.Items.Add(material.Name);
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

                MaterialUserLB.Items.Clear();
                foreach (var guest in LogicCollection.GuestLogic.GetGuestsByEvent(_event))
                {
                    if (guest.PassID == GebruikersNummerTb.Text)
                    {
                        foreach (var material in LogicCollection.MaterialLogic.GetReservedMaterialsByGuest(guest))
                        {
                            MaterialUserLB.Items.Add(material.Name);
                        }
                    }
                }
            }

            //Refresh storage listbox
            MaterialStorageLB.Items.Clear();
            foreach (var material in LogicCollection.MaterialLogic.GetAllByEventAndNonReserved(_event))
            {
                MaterialStorageLB.Items.Add(material.Name);
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
        private void CategorieCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CategorieCb.Text == "Any" || CategorieCb.Text == "")
            {
                UpdateListBox();
            }
            else
            {
                UpdateListBox(CategorieCb.Text);
            }
        }

        /// <summary>
        /// Index changed of material storage listbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MaterialStorageLB_SelectedIndexChanged(object sender, EventArgs e)
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
        private void NeemTerugBtn_Click(object sender, EventArgs e)
        {
            var boxes = new List<TextBox>();
            boxes.Add(GebruikersNummerTb);
            boxes.Add(GebruikersNaamTb);

            if (FieldsFilled(boxes) && MaterialUserLB.Items.Count > 0 && MaterialUserLB.SelectedIndex != -1)
            {
                foreach (var material in LogicCollection.MaterialLogic.GetReservedMaterialsByGuest(LogicCollection.GuestLogic.GetByRfid(GebruikersNummerTb.Text)))
                {
                    if (material.Name == MaterialUserLB.Text)
                    {
                        if(!LogicCollection.MaterialLogic.RemoveReservation(material))
                            MessageBox.Show("Material unsuccesfully deleted: " + material.Name);
                    }
                }
            }
            UpdateListBoxAndCategory();
        }

        /// <summary>
        /// Moves material of the storage back to a guest
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void VerhuurProductBtn_Click(object sender, EventArgs e)
        {
            //Specify required textboxes
            var boxes = new List<TextBox>();
            boxes.Add(GebruikersNummerTb);
            boxes.Add(GebruikersNaamTb);
            boxes.Add(ArtikelnummerTb);
            boxes.Add(ProductTb);

            if (FieldsFilled(boxes) && MaterialStorageLB.Items.Count > 0 && MaterialStorageLB.SelectedIndex != -1)
            {
                foreach (var material in LogicCollection.MaterialLogic.GetAllByEvent(_event))
                {
                    if (material.ID.ToString() == ArtikelnummerTb.Text)
                    {
                        LogicCollection.MaterialLogic.AddReservation(material, LogicCollection.GuestLogic.GetByRfid(GebruikersNummerTb.Text).ID,
                            _event.StartDate, _event.EndDate);
                    }
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
        private void VerwijderProductBtn_Click(object sender, EventArgs e)
        {
            var remove = new List<Material>();
            foreach (var material in LogicCollection.MaterialLogic.GetAllByEvent(_event))
            {
                if (ArtikelnummerTb.Text == material.ID.ToString() && ProductTb.Text == material.Name)
                {
                    remove.Add(material);
                    if (MaterialStorageLB.Items.Count >= 1 && MaterialStorageLB.SelectedItem != null)
                    {
                        MaterialStorageLB.Items.Remove(MaterialStorageLB.SelectedItem.ToString());
                    }
                }
            }
            foreach (var material in remove)
            {
                if (LogicCollection.MaterialLogic.Delete(material))
                    MessageBox.Show("Succesfully deleted material");
                else
                {
                    MessageBox.Show("Failed to delete material");
                }
                LogicCollection.MaterialLogic.GetAllByEvent(_event).Remove(material);
            }
        }

        /// <summary>
        /// Changes the values of a material in storage
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// werkend
        private void ProductWijzigenBtn_Click(object sender, EventArgs e)
        {
            var boxes = new List<TextBox>();
            boxes.Add(ProductNewTb);
            boxes.Add(ArtikelnummerTb);
            boxes.Add(ProductTb);
            if (FieldsFilled(boxes))
            {
                foreach (var material in LogicCollection.MaterialLogic.GetAllByEvent(_event))
                {
                    if (material.ID.ToString() == ArtikelnummerTb.Text)
                    {
                        if (!string.IsNullOrEmpty(TypeNewTb.Text))
                        {

                            LogicCollection.MaterialLogic.Insert(new MaterialType(0, TypeNewTb.Text));
                            LogicCollection.MaterialLogic.Update(new Material(material.ID, ProductNewTb.Text, material.EventID,
                                LogicCollection.MaterialLogic.GetByName(TypeNewTb.Text).ID));
                        }
                        else
                        {
                            LogicCollection.MaterialLogic.Update(new Material(material.ID, ProductNewTb.Text, material.EventID,
                                material.TypeID));
                        }
                    }
                }
            UpdateListBoxAndCategory();
            UpdateArtNumberArtName();
            }
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
        private void ProductToevoegenBtn_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(ProductNewTb.Text))
            {
                if (!string.IsNullOrEmpty(TypeNewTb.Text))
                {
                    var typeAppearsAlready = false;
                    foreach (var mt in LogicCollection.MaterialLogic.GetAll())
                    {
                        if (mt.Name == TypeNewTb.Text)
                        {
                            typeAppearsAlready = true;
                        }
                    }
                    if (!typeAppearsAlready)
                    {
                        LogicCollection.MaterialLogic.Insert(new MaterialType(0, TypeNewTb.Text));
                        LogicCollection.MaterialLogic.Insert(new Material(0, ProductNewTb.Text, _event.ID,
                            LogicCollection.MaterialLogic.GetByName(TypeNewTb.Text).ID));
                    }
                    else
                    {
                        LogicCollection.MaterialLogic.Insert(new Material(0, ProductNewTb.Text, _event.ID,
                            LogicCollection.MaterialLogic.GetByName(TypeNewTb.Text).ID));
                    }
                }
                else
                {
                    LogicCollection.MaterialLogic.Insert(new Material(0, ProductNewTb.Text, _event.ID));
                }
                UpdateListBoxAndCategory();
                UpdateArtNumberArtName();
            }
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
            UpdateListBoxAndCategory();
        }
        #endregion
    }
}
