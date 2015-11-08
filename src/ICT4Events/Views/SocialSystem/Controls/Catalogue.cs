using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using SharedModels.Enums;
using SharedModels.FTP;
using SharedModels.Logic;
using SharedModels.Models;

namespace ICT4Events.Views.SocialSystem.Controls
{
    public partial class Catalogue : UserControl
    {
        private readonly User _user;
        private readonly Event _event;
        private Media _media;
        private Button _delete;

        public Catalogue(Event ev,User user)
        {
            InitializeComponent();
            _user = user;
            _event = ev;
        }

        private void Catalogue_Load(object sender, EventArgs e)
        {
            LoadCatalogue();
            // Makes delete button & loads upload usercontrol
            tbpLoadUcUpload.Controls.Add(new UcUpload(_user, _event), 1, 2);
            _delete = new Button();
            _delete.Text = @"Verwijderen Media";
            _delete.Name = "lblDeleteMedia";
            _delete.Click += lblDeleteMedia_LinkClicked;
            _delete.Dock = DockStyle.Left;
            _delete.Visible = false;
            tbpButtons.Controls.Add(_delete, 0, 0);
        }

        private void trvCatalogue_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (trvCatalogue.SelectedNode.Parent != null)
            {
                string child = e.Node.Text;
                string mediaId = child.Substring(0, child.IndexOf("-", StringComparison.Ordinal)).Trim();

                _media = LogicCollection.MediaLogic.GetById(Convert.ToInt32(mediaId));

                picCatalogue.ImageLocation = $"{FtpHelper.ServerHardLogin}/{_event.ID}/{_media.UserID}/{_media.Path}";
                _delete.Visible = true;
            }
        }

        /// <summary>
        /// Delete media from catalogue
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblDeleteMedia_LinkClicked(object sender, EventArgs e)
        {
            MessageBox.Show(LogicCollection.MediaLogic.DeleteMedia(_media) ? "Verwijderd!" : "Verwijderen mislukt");
            _delete.Visible = false;
            picCatalogue.ImageLocation = null;
            picCatalogue.Invalidate();
            LoadCatalogue();
        }

        private void LoadCatalogue()
        {
            trvCatalogue.Nodes.Clear();
            // User
            if (_user.Permission == PermissionType.User)
            {
                var listMedia = LogicCollection.MediaLogic.GetAllById(_user.ID, _event);
                TreeNode[] arrayofNodes = listMedia.Select(I => new TreeNode($"{I.ID} - {I.Path}")).ToArray();
                TreeNode treeNode = new TreeNode($"{_user.Name} {_user.Surname}", arrayofNodes);
                trvCatalogue.Nodes.Add(treeNode);
            }
            else if (_user.Permission == PermissionType.Administrator || _user.Permission == PermissionType.Employee)
            {
                // Admin
                var listMedia = LogicCollection.MediaLogic.GetAllMedia(_event);
                var listGuests = new List<int>();
                foreach (Media media in listMedia.Where(media => !listGuests.Contains(media.UserID)))
                {
                    listGuests.Add(media.UserID);
                }

                foreach (int i in listGuests)
                {
                    var mediaUser = LogicCollection.UserLogic.GetById(i);
                        TreeNode[] arrayofNodes =
                            listMedia.Where(x => x.UserID == mediaUser.ID)
                                .Select(I => new TreeNode($"{I.ID} - {I.Path}"))
                                .ToArray();
                    TreeNode treeNode = new TreeNode($"{mediaUser.Name} {mediaUser.Surname}", arrayofNodes);
                    trvCatalogue.Nodes.Add(treeNode);
                }

            }
        }

        private void btnReload_Click_1(object sender, EventArgs e)
        {
            LoadCatalogue();
        }
    }
}
