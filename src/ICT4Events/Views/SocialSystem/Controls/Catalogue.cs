using System;
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

        public Catalogue(Event ev,User user)
        {
            InitializeComponent();
            _user = user;
            _event = ev;
        }

        private void Catalogue_Load(object sender, EventArgs e)
        {
            if (_user.Permission == PermissionType.User)
            {
                var listMedia = LogicCollection.MediaLogic.GetAllByGuest((Guest) _user);
                TreeNode[] arrayofNodes = listMedia.Select(I => new TreeNode(I.Path)).ToArray();
                TreeNode treeNode = new TreeNode($"{_user.ID} - {_user.Name} {_user.Surname}", arrayofNodes);
                trvCatalogue.Nodes.Add(treeNode);
                tbpLoadUcUpload.Controls.Add(new UcUpload(_user, _event), 1, 1);
                
            }
        }


        private void trvCatalogue_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string userID = e.Node.Parent.Text.Substring(0, e.Node.Parent.Text.IndexOf("-", StringComparison.Ordinal)).Trim();
            picCatalogue.ImageLocation = $"{FtpHelper.ServerHardLogin}/{_event.ID}/{userID}/{e.Node.Text}";

            LinkLabel delete = new LinkLabel();
            delete.Text = @"Verwijderen Media";
            delete.Location = new Point(435, 255);
            this.Controls.Add(delete);
        }
    }
}
