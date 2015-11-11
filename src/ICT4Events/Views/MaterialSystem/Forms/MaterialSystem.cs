using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        private RFID _rfid;
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

        private void rfid_Attach(object sender, AttachEventArgs e)
        {
            var attached = (RFID)sender;
            if (_rfid.outputs.Count > 0)
            {
                _rfid.Antenna = true;
            }
        }

        private void rfid_Detach(object sender, DetachEventArgs e)
        {
            var detached = (RFID)sender;
        }

        private void rfid_Tag(object sender, TagEventArgs e)
        {
            //Refresh user listbox
            btnReturn.Enabled = true;
            txtGuestPassId.Text = e.Tag;
            lsbUserMaterial.Items.Clear();
                foreach (
                    var material in
                        LogicCollection.GuestLogic.GetGuestsByEvent(_event)
                            .Where(guest => guest.PassID == e.Tag)
                            .SelectMany(guest => LogicCollection.MaterialLogic.GetReservedMaterialsByGuest(guest)))
            {
                    lsbUserMaterial.Items.Add(material);
                }

            var g = LogicCollection.GuestLogic.GetByRfid(e.Tag, _event);
            if (g != null)
            {
                txtUserName.Text = $"{g.Name} {g.Surname}";
            }
            else
            {
                MessageBox.Show("Niemand gevonden.");
            }

            Refresh();
        }

        private void rfid_TagLost(object sender, TagEventArgs e)
        {
        }
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
                    txtMaterialID.Text = ((Material)lsbMaterialStorage.SelectedItem).ID.ToString();
                    txtMaterialName.Text = ((Material)lsbMaterialStorage.SelectedItem).ToString();
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
            //Refresh storage listbox
            lsbMaterialStorage.Items.Clear();
            foreach (var material in LogicCollection.MaterialLogic.GetAllByEventAndNonReserved(_event))
            {
                lsbMaterialStorage.Items.Add(material);
            }

            //Refresh categorie combobox
            var savedIndex = cbCategory.SelectedIndex;
            cbCategory.Items.Clear();
            cbCategory.Items.Add("Any");
            foreach (var mt in LogicCollection.MaterialLogic.GetAll())
            {
                cbCategory.Items.Add(mt);
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
                            .Where(guest => guest.PassID == txtGuestPassId.Text)
                            .SelectMany(guest => LogicCollection.MaterialLogic.GetReservedMaterialsByGuest(guest)))
                {
                    lsbUserMaterial.Items.Add(material);
                }
            }

            //Refresh storage listbox
            lsbMaterialStorage.Items.Clear();
            foreach (
                var material in
                    LogicCollection.MaterialLogic.GetAllByEventAndNonReserved(_event)
                        .Where(material => material.TypeID == LogicCollection.MaterialLogic.GetByName(categorie).ID))
            {
                lsbMaterialStorage.Items.Add(material);
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
                            .Where(guest => guest.PassID == txtGuestPassId.Text)
                            .SelectMany(guest => LogicCollection.MaterialLogic.GetReservedMaterialsByGuest(guest)))
                {
                    lsbUserMaterial.Items.Add(material);
                }
            }

            //Refresh storage listbox
            lsbMaterialStorage.Items.Clear();
            foreach (var material in LogicCollection.MaterialLogic.GetAllByEventAndNonReserved(_event))
            {
                lsbMaterialStorage.Items.Add(material);
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
            var boxes = new List<TextBox> { txtGuestPassId, txtUserName };
            if (FieldsFilled(boxes) && lsbUserMaterial.Items.Count > 0 && lsbUserMaterial.SelectedIndex != -1)
            {
                var convertedToMaterial = (Material) lsbUserMaterial.SelectedItem;
                if (convertedToMaterial.EndDate.Value < DateTime.Now)
                {
                    MessageBox.Show($"Product {((Material) lsbUserMaterial.SelectedItem).Name} is {Math.Round((DateTime.Now - ((Material) lsbUserMaterial.SelectedItem).EndDate).Value.TotalDays)} dag(en) te laat ingeleverd.");
                }
                LogicCollection.MaterialLogic.RemoveReservation(((Material)lsbUserMaterial.SelectedItem));
            }
            UpdateListBox();
            UpdateListBoxAndCategory();
        }

        /// <summary>
        /// Moves material of the storage back to a guest
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRentMaterial_Click(object sender, EventArgs e)
        {
            var boxes = new List<TextBox> { txtGuestPassId, txtUserName, txtMaterialID, txtMaterialName };

            if (FieldsFilled(boxes) && lsbMaterialStorage.Items.Count > 0 && lsbMaterialStorage.SelectedIndex != -1)
            {
                LogicCollection.MaterialLogic.AddReservation((Material)lsbMaterialStorage.SelectedItem,
                    LogicCollection.GuestLogic.GetByRfid(txtGuestPassId.Text, _event).ID,
                    dtpStart.Value, dtpEnd.Value);
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
            if (!LogicCollection.MaterialLogic.Delete(((Material)lsbMaterialStorage.SelectedItem)))
            {
                MessageBox.Show($"Materiaal verwijderen mislukt.\r\nMateriaal: {lsbMaterialStorage.SelectedItem}.");
            }
            UpdateListBoxAndCategory();
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
            foreach (var material in
                LogicCollection.MaterialLogic.GetAllByEvent(_event)
                    .Where(material => material.ID.ToString() == txtMaterialID.Text))
            {
                if (!string.IsNullOrEmpty(txtNewMaterialType.Text))
                {

                    LogicCollection.MaterialLogic.Insert(new MaterialType(0, txtNewMaterialType.Text));
                    LogicCollection.MaterialLogic.Update(new Material(material.ID, txtNewMaterialName.Text,
                        material.EventID,
                        LogicCollection.MaterialLogic.GetByName(txtNewMaterialType.Text).ID));
                }
                else
                {
                    LogicCollection.MaterialLogic.Update(new Material(material.ID, txtNewMaterialName.Text,
                        material.EventID,
                        material.TypeID));
                }
            }
            UpdateListBoxAndCategory();
            UpdateArtNumberArtName();
        }

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
            if (_event.StartDate > DateTime.Now && _event.EndDate < DateTime.Now)
            {
                dtpStart.Value = dtpStart.MinDate = dtpEnd.MinDate = DateTime.Today;
                dtpEnd.Value = dtpEnd.MaxDate = dtpStart.MaxDate = _event.EndDate;
            }
            else
            {
                dtpStart.Value = dtpStart.MinDate = dtpEnd.MinDate = _event.StartDate;
                dtpEnd.Value = dtpEnd.MaxDate = dtpStart.MaxDate = _event.EndDate;
            }
            _rfid = new RFID();
            _rfid.Attach += rfid_Attach;
            _rfid.Detach += rfid_Detach;
            _rfid.Tag += rfid_Tag;
            _rfid.TagLost += rfid_TagLost;
            openCmdLine(_rfid);
        }
        #endregion

        private void openCmdLine(Phidget p)
        {
            openCmdLine(p, null);
        }

        private void openCmdLine(Phidget p, string pass)
        {
            var serial = -1;
            string logFile = null;
            var port = 5001;
            string host = null;
            bool remote = false, remoteIp = false;
            var args = Environment.GetCommandLineArgs();
            var appName = args[0];

            try
            {
                for (var i = 1; i < args.Length; i++)
                {
                    if (args[i].StartsWith("-"))
                    {
                        switch (args[i].Remove(0, 1).ToLower())
                        {
                            case "l":
                                logFile = args[++i];
                                break;
                            case "n":
                                serial = int.Parse(args[++i]);
                                break;
                            case "r":
                                remote = true;
                                break;
                            case "s":
                                remote = true;
                                host = args[++i];
                                break;
                            case "p":
                                pass = args[++i];
                                break;
                            case "i":
                                remoteIp = true;
                                host = args[++i];
                                if (host.Contains(":"))
                                {
                                    port = int.Parse(host.Split(':')[1]);
                                    host = host.Split(':')[0];
                                }

                                break;
                            default:
                                goto usage;
                        }
                    }
                    else
                    {
                        goto usage;
                    }
                }

                if (logFile != null)
                {
                    Phidget.enableLogging(Phidget.LogLevel.PHIDGET_LOG_INFO, logFile);
                }

                if (remoteIp)
                {
                    p.open(serial, host, port, pass);
                }
                else if (remote)
                {
                    p.open(serial, host, pass);
                }
                else
                {
                    p.open(serial);
                }

                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            usage:
            var sb = new StringBuilder();
            sb.AppendLine("Invalid Command line arguments." + Environment.NewLine);
            sb.AppendLine("Usage: " + appName + " [Flags...]");
            sb.AppendLine("Flags:\t-n   serialNumber\tSerial Number, omit for any serial");
            sb.AppendLine("\t-l   logFile\tEnable phidget21 logging to logFile.");
            sb.AppendLine("\t-r\t\tOpen remotely");
            sb.AppendLine("\t-s   serverID\tServer ID, omit for any server");
            sb.AppendLine("\t-i   ipAddress:port\tIp Address and Port. Port is optional, defaults to 5001");
            sb.AppendLine("\t-p   password\tPassword, omit for no password" + Environment.NewLine);
            sb.AppendLine("Examples: ");
            sb.AppendLine(appName + " -n 50098");
            sb.AppendLine(appName + " -r");
            sb.AppendLine(appName + " -s myphidgetserver");
            sb.AppendLine(appName + " -n 45670 -i 127.0.0.1:5001 -p paswrd");
            MessageBox.Show(sb.ToString(), "Argument Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            Application.Exit();
        }

        private void Reset()
        {
            txtGuestPassId.Text = string.Empty;
            txtUserName.Text = string.Empty;
            lsbUserMaterial.Items.Clear();
            btnReturn.Enabled = false;
        }
    }
}
