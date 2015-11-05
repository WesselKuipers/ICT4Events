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
    public partial class MaterialSystem : Form
    {
        #region Local Variables
        private readonly Event _event;
        private readonly IGuestContext _contextGuest;
        private readonly IMaterialContext _contextMaterial;
        private readonly IMaterialTypeContext _contextMaterialType;
        private bool _rfidScanned;
        #endregion


        public MaterialSystem(Event ev)
                {
                    InitializeComponent();
                    _event = ev;
                    _contextGuest = new GuestOracleContext();
                    _contextMaterial = new MaterialOracleContext();
                    _contextMaterialType = new MaterialTypeOracleContext();

                    //TODO Rfid Setting
                    _rfidScanned = false;
                }


        #region Local Functions
        //Checks wether a id already occurs in _materials
        private bool UniqueID(int id)
        {
            var check = true;
            foreach (var material in _contextMaterial.GetAllByEvent(_event))
            {
                if (material.ID == id)
                {
                    check = false;
                }
            }
            if (!check)
                MessageBox.Show("Artikelnummer zit al in de lijst van materialen");
            return check;
        }
        
        //Checks if fields is/are filled
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

        private void UpdateArtNummerArtNaam()
        {
            if (MaterialStorageLB.SelectedIndex != -1)
            {
                foreach (var material in _contextMaterial.GetAllByEvent(_event))
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

        private void AddMaterial(Material material)
        {
            //TODO MaterialLogic.AddMaterial(material);
            MessageBox.Show("Test");
            _contextMaterial.GetAllByEvent(_event).Add(material);
            UpdateListBox();
            UpdateArtNummerArtNaam();
            AddCategorie();
        }

        private void EditMaterial(Material oldMaterial, Material newMaterial)
        {
            var remove = new List<Material>();
            var add = new List<Material>();

            //Lots of for eaches due to resolving InvalidOperationException
            foreach (var mat in _contextMaterial.GetAllByEvent(_event))
                if (mat == oldMaterial)
                    remove.Add(mat);

            foreach (var mat in _contextMaterial.GetAllByEvent(_event))
                if (mat == oldMaterial)
                    add.Add(newMaterial);

            foreach (var mat in add)
                _contextMaterial.GetAllByEvent(_event).Add(newMaterial);

            foreach (var mat in remove)
                _contextMaterial.GetAllByEvent(_event).Remove(mat);

            //TODO MaterialLogic.EditMaterial(newMaterial);

            AddCategorie();
            UpdateListBox();
            UpdateArtNummerArtNaam();
        }

        //Adds a type and updates the category
        private void AddCategorie()
        {
            foreach (var material in _contextMaterial.GetAllByEvent(_event))
            {
                if ( string.IsNullOrEmpty(_contextMaterialType.GetById(material.TypeID).Name))
                {
                    if (!CategorieCb.Items.Contains(_contextMaterialType.GetById(material.TypeID).Name))
                    {
                        CategorieCb.Items.Add(_contextMaterialType.GetById(material.TypeID).Name);
                    }
                }
            }
        }

        //Updates both User and Storage
        private void UpdateListBox()
        {
            MaterialStorageLB.Items.Clear();
            MaterialUserLB.Items.Clear();

            foreach (var material in _contextMaterial.GetAllByEvent(_event))
                if (material.GuestID == null)
                    MaterialStorageLB.Items.Add(material.Name);

            foreach (var material in _contextMaterial.GetAllByEvent(_event))
                if (material.GuestID != null) //TODO Null Reference Fixen
                    MaterialUserLB.Items.Add(material.Name);
        }

        //Just updates Storage based on category
        private void UpdateListBox(string category)
        {
            MaterialStorageLB.Items.Clear();
            MaterialUserLB.Items.Clear();

            foreach (var material in _contextMaterial.GetAllByEvent(_event))
                if (_contextGuest.GetById(material.GuestID) == null && _contextMaterialType.GetById(material.TypeID).Name == category)
                    MaterialStorageLB.Items.Add(material.Name);
        }
        #endregion

        //Just updates ... based on guest
        private void UpdateListBox(Guest guest)
        {
            GebruikersNaamTb.Text = guest.Name;
            GebruikersNummerTb.Text = guest.PassID;

            MaterialStorageLB.Items.Clear();

            if (_rfidScanned)
                MaterialUserLB.Items.Clear();

            foreach (var material in _contextMaterial.GetAllByEvent(_event))
            {
                if (material.GuestID == null)
                    MaterialStorageLB.Items.Add(material.Name);
                else if (_contextGuest.GetById(material.GuestID).Name == guest.Name && _contextGuest.GetById(material.GuestID).PassID == guest.PassID)
                    MaterialUserLB.Items.Add(material.Name);
            }
        }


        #region Eventhandlers
        #region SelectedIndexChanged
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

        private void MaterialStorageLB_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateArtNummerArtNaam();
        }
        #endregion

        #region Click
        private void NeemTerugBtn_Click(object sender, EventArgs e)
        {
            //Predetermine variable, because foreach will nullify MaterialUserLb
            var item = MaterialUserLB.SelectedItem.ToString();

            //Specify required textboxes
            var boxes = new List<TextBox>();
            boxes.Add(GebruikersNummerTb);
            boxes.Add(GebruikersNaamTb);

            if (FieldsFilled(boxes) && MaterialUserLB.Items.Count > 0 && MaterialUserLB.SelectedIndex != -1)
            {
                MessageBox.Show("Test");
                foreach (var material in _contextMaterial.GetAllByEvent(_event))
                {
                    if (_contextGuest.GetById(material.GuestID) == null)
                    {
                        //NULL Reference Fix
                    }

                    else if (item == material.Name && _contextGuest.GetById(material.GuestID) != null)
                    {
                        if (_contextGuest.GetById(material.GuestID).Name == GebruikersNaamTb.Text && _contextGuest.GetById(material.GuestID).PassID == GebruikersNummerTb.Text)
                        {
                            //Dissociate a guest with a material
                            material.GuestID = null;
                            //Meningsverschil in startdate/now
                            if(!_contextMaterial.Update(material))
                                MessageBox.Show("Failed to update material");
                            else
                            {
                                MessageBox.Show("Succesfully updated material: " + material.Name);
                            }   
                        }
                    }
                }
            }
            UpdateListBox();
        }

        //Tested with succes
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
                foreach (var material in _contextMaterial.GetAllByEvent(_event))
                {
                    if (material.Name == ProductTb.Text && material.ID.ToString() == ArtikelnummerTb.Text)
                    {
                        foreach (var guest in _contextGuest.GetAllByEvent(_event))
                        {
                            if (guest.PassID == GebruikersNummerTb.Text)
                            {
                                _rfidScanned = true; //Temporarily true for testing purposes

                                //Associate a guest with a material
                                material.GuestID = guest.ID;
                                //MessageBox.Show(_event.StartDate.ToString() + " " + _event.EndDate.ToString());
                                //Meningsverschil in startdate/now
                                if (_event.StartDate != _event.EndDate)
                                    _contextMaterial.AddReservation(material, guest.ID, _event.StartDate, _event.EndDate);
                                else
                                    _contextMaterial.AddReservation(material, guest.ID, _event.StartDate, _event.EndDate.AddDays(1));
                                UpdateListBox(guest);
                            }
                        }
                    }
                }
            }
            UpdateArtNummerArtNaam();
        }

        //Tested with succes
        private void VerwijderProductBtn_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(_contextMaterial.GetAllByEvent(_event).Count.ToString());

            var remove = new List<Material>();
            foreach (var material in _contextMaterial.GetAllByEvent(_event))
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
                //TODO Delete material from database
                if (_contextMaterial.Delete(material))
                    MessageBox.Show(_contextMaterial.GetAllByEvent(_event).Count.ToString());
                else
                {
                    MessageBox.Show("Failed to delete material");
                }
                //End of TODO
                _contextMaterial.GetAllByEvent(_event).Remove(material);
            }
            //MessageBox.Show(_contextMaterial.GetAllByEvent(_event).Count.ToString());
        }

        private void ProductWijzigenBtn_Click(object sender, EventArgs e)
        {
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

        private void ProductToevoegenBtn_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(ProductNewTb.Text))
            {
                if(!string.IsNullOrEmpty(TypeNewTb.Text))
                    AddMaterial(new Material(0, ProductNewTb.Text, _event.ID, _contextMaterialType.GetByName(TypeNewTb.Text).ID));
                else
                    AddMaterial(new Material(0, ProductNewTb.Text, _event.ID, _contextMaterialType.GetByName("Overige").ID));
            }
        }
        #endregion

        private void MaterialSystem_Load(object sender, EventArgs e)
        {
            AddCategorie();
            foreach (var guest in _contextGuest.GetAllByEvent(_event))
            {
                //Testsubject Stefano
                if(guest.Name == "Stefano")
                    UpdateListBox(guest);
            }
            

            //Test
            /*
            var temp = "";
            foreach (var guest in _contextGuest.GetAllByEvent(_event))
            {
                temp += ("Guestpasnummer: " + guest.PassID  + "    Guestnaam: " + guest.Name + Environment.NewLine);
            }
            MessageBox.Show(temp + Environment.NewLine + "Guest Amount: " +  _contextGuest.GetAllByEvent(_event).Count);
            */
            //Results: https://gyazo.com/bdd1c2201cf2cf1fd4d3c1d4df0a8e8b

        }
        #endregion
    }
}
