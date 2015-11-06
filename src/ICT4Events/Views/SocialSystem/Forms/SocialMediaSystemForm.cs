using System;
using System.Windows.Forms;
using ICT4Events.Views.SocialSystem.Controls;
using SharedModels.Enums;
using SharedModels.Models;

namespace ICT4Events.Views.SocialSystem.Forms
{
    public partial class SocialMediaSystemForm : Form
    {
        private readonly Event _event;
        private readonly User _user;

        public SocialMediaSystemForm(User user, Event ev)
        {
            InitializeComponent();
            _user = user;
            _event = ev;
        }
        
        private void SocialMediaSystemForm_Load(object sender, EventArgs e)
        {

            var timeLine = new TimeLine(_user, _event) {Dock = DockStyle.Fill};
            tbTimeLine.Controls.Add(timeLine);

            var makePost = new MakePost(_user, _event)
            {
                Anchor = (AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top)
            };
            tbMakePost.Controls.Add(makePost);

            var tbSearch = new TabPage("Zoek op tags");
            var searchByTag = new SearchByTag(_user, _event) { Dock = DockStyle.Fill };
            tbControlSMSF.TabPages.Add(tbSearch);
            tbSearch.Controls.Add(searchByTag);

            var tbMedia = new TabPage("Catalogus");
            var catlogue = new Catalogue(_event, _user) { Dock = DockStyle.Fill };
            tbControlSMSF.TabPages.Add(tbMedia);
            tbMedia.Controls.Add(catlogue);

            if (_user.Permission == PermissionType.Employee || _user.Permission == PermissionType.Administrator)
            {
                TabPage reports = new TabPage("Gerapporteerde Posts");
                tbControlSMSF.TabPages.Add(reports);
                reports.Controls.Add(new ReportSection(_user, _event));
            }
        }
    }
}
