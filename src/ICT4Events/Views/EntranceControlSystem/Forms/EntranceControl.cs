using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ICT4Events.Views.Reservation_System.Forms;
using Phidgets;
using Phidgets.Events;
using SharedModels.Logic;
using SharedModels.Models;

namespace ICT4Events.Views.EntranceControlSystem.Forms
{
    /// <summary>
    /// Main Form
    /// </summary>
    public partial class EntranceControl : Form
    {
        private RFID _rfid;
        private List<Guest> _guests;
        private readonly Event _event;
        private Guest _searchGuest;

        /// <summary>
        /// Initialize a new instance of the <see cref="EntranceControl"/> class.
        /// </summary>
        public EntranceControl(Event ev)
        {
            InitializeComponent();
            _event = ev;
            _guests = LogicCollection.GuestLogic.GetGuestsByEvent(_event);
        }

        private void EntraceControl_Load(object sender, EventArgs e)
        {
            _rfid = new RFID();
            _rfid.Attach += rfid_Attach;
            _rfid.Detach += rfid_Detach;
            _rfid.Tag += rfid_Tag;
            _rfid.TagLost += rfid_TagLost;
            openCmdLine(_rfid);
        }

        private void rfid_Attach(object sender, AttachEventArgs e)
        {
            if (_rfid.outputs.Count > 0)
            {
                _rfid.Antenna = true;
            }
        }

        private void rfid_Detach(object sender, DetachEventArgs e)
        {
            var detached = (RFID)sender;
        }

        private void btnZoeken_Click(object sender, EventArgs e)
        {
            var id = txtRFIDIDSearch.Text;

            if (string.IsNullOrWhiteSpace(id))
            {
                MessageBox.Show("ID is leeg");
                return;
            }

            LoadSearchGuest(id);
        }

        public void btnShowPresentGuests_Click(object sender, EventArgs e)
        {
            LoadListPresentGuestsAndReservations();
            Refresh();
        }

        private void rfid_Tag(object sender, TagEventArgs e)
        {
            txtRFIDIDSearch.Text = e.Tag;
            txtRFIDPassCode.Text = e.Tag;
            var id = txtRFIDIDSearch.Text;
            LoadSearchGuest(id);
        }

        private void rfid_TagLost(object sender, TagEventArgs e)
        {
            txtRFIDIDSearch.Text = string.Empty;
            txtName.Text = string.Empty;
            txtLastName.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtPhoneNumber.Text = string.Empty;
            txtLocationId.Text = string.Empty;
            chbPaid.Checked = false;

            btnCheckIn.Enabled = false;
            btnCheckOut.Enabled = false;
            btnPay.Enabled = false;
        }

        #region Command line open functions
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
        #endregion

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            _rfid.Attach -= rfid_Attach;
            _rfid.Detach -= rfid_Detach;
            _rfid.Tag -= rfid_Tag;
            _rfid.TagLost -= rfid_TagLost;
            Application.DoEvents();
            _rfid.close();
        }

        private void tabControl1_Click(object sender, EventArgs e)
        {
            LoadListPresentGuestsAndReservations();
            Refresh();
        }
        private void LoadSearchGuest(string rfid)
        {
            _searchGuest = LogicCollection.GuestLogic.GetByRfid(rfid);
            if (_searchGuest != null)
            {
                txtName.Text = _searchGuest.Name;
                txtLastName.Text = _searchGuest.Surname;
                txtLocationId.Text = _searchGuest.LocationID.ToString();
                txtPhoneNumber.Text = _searchGuest.Telephone;
                txtEmail.Text = _searchGuest.Username;
                chbPaid.Checked = _searchGuest.Paid;
                btnPay.Enabled = !_searchGuest.Paid;
                btnCheckIn.Enabled = !_searchGuest.Present;
                btnCheckOut.Enabled = _searchGuest.Present;
            }

            Refresh();
        }
        private void LoadListPresentGuestsAndReservations()
        {
            lsvPresentGuests.Items.Clear();
            _guests = LogicCollection.GuestLogic.GetGuestsByEvent(_event);
            foreach (var guest in _guests.Where(x => x.Present))
            {
                string[] row = { $"{guest.Name} {guest.Surname}", guest.Username, guest.Address, guest.Telephone };
                var item = new ListViewItem(row);
                lsvPresentGuests.Items.Add(item);
            }

            lsvReserved.Items.Clear();
            var reservedItems = LogicCollection.MaterialLogic.GetAllReservedMaterials(_event);
            foreach (var reserverd in reservedItems)
            {
                var guestId = 0;
                if (reserverd.GuestID.HasValue)
                {
                    guestId = reserverd.GuestID.Value;
                    var user = LogicCollection.UserLogic.GetById(guestId);
                    Material material = null;
                    foreach (var m in LogicCollection.MaterialLogic.GetAllByEvent(_event).Where(m => m.ID == reserverd.ID))
                        material = m;

                    if (material == null) continue;
                    
                    string[] row = { $"{user.Name} {user.Surname}", material.Name, reserverd.StartDate.ToString(), reserverd.EndDate.ToString() };
                    var item = new ListViewItem(row);
                    lsvReserved.Items.Add(item);
                }
            }

            cmbListOfGuest.Items.Clear();
            var listofGuestWithoutPass = LogicCollection.GuestLogic.GetGuestsByEvent(_event).Where(x => string.IsNullOrWhiteSpace(x.PassID));
            foreach (var guestPass in listofGuestWithoutPass)  
            {
                cmbListOfGuest.Items.Add(guestPass);
            }
        }

        private void btnCheckIn_Click(object sender, EventArgs e)
        {
            if (_searchGuest.Paid)
            {
                chbPaid.Checked = true;
                _searchGuest.Present = true;
                // Update check
                if (LogicCollection.GuestLogic.UpdateGuest(_searchGuest))
                {
                    //MessageBox.Show($"Welkom op het evenement {_searchGuest.Name}");
                    btnCheckOut.Enabled = true;
                    btnCheckIn.Enabled = false;
                }
                else
                {
                    MessageBox.Show("ERROR: Er is iets misgegaan.");
                }
            }
            else
            {
                MessageBox.Show("ERROR: Gebruiker dient eerst te betalen.");
            }
        }
        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            _searchGuest.Present = false;
            // Update guest
            if (LogicCollection.GuestLogic.UpdateGuest(_searchGuest))
            {
                //MessageBox.Show($"We gaan je missen {_searchGuest.Name}");
                btnCheckOut.Enabled = false;
                btnCheckIn.Enabled = true;
            }
            else
            {
                MessageBox.Show("ERROR: Er is iets misgegaan.");
            }
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            var location = LogicCollection.LocationLogic.GetLocationByID(_searchGuest.LocationID);

            var totalAmount = location.Price;

            if (new GuestPaymentForm(totalAmount).ShowDialog() != DialogResult.OK) return;
                _searchGuest.Paid = true;
                LogicCollection.GuestLogic.UpdateGuest(_searchGuest);

            btnPay.Enabled = false;
        }

        private void txtRFIDIDSearch_TextChanged(object sender, EventArgs e)
        {
            btnSearch.Enabled = !string.IsNullOrWhiteSpace(txtRFIDIDSearch.Text);
        }

        private void btnBindRfid_Click(object sender, EventArgs e)
        {
            var rfid = txtRFIDPassCode.Text;
            var g = (Guest) cmbListOfGuest.SelectedItem;
            if (g != null)
            {
                g.PassID = rfid;
                LogicCollection.GuestLogic.UpdateGuest(g);
                MessageBox.Show("Pas koppelen is gelukt");
                txtRFIDPassCode.Text = "";
                cmbListOfGuest.SelectedIndex = -1;
            }
            else
            {
                MessageBox.Show("Selecteer een bezoeker.");
            }
        }
    }
}