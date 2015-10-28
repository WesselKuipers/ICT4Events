using System;
using System.IO;
using System.Windows.Forms;
using ICT4Events.Views.SocialSystem.Forms;
using SharedModels.Data.OracleContexts;
using SharedModels.FTP;
using SharedModels.Logic;
using SharedModels.Models;

namespace ICT4Events.Views.SocialSystem.Controls
{
    public partial class PostFeed : UserControl
    {
        private readonly Post _post;
        private readonly Event _event;
        private readonly User _user;
        private Media _media;
        private readonly UserOracleContext _logicUser;
        private readonly MediaOracleContext _logicMeida;
        private readonly PostLogic _logicPost;
        private readonly GuestLogic _logicGuest;

        public PostFeed(Post post, Event ev)
        {
            InitializeComponent();
            _post = post;
            _event = ev;
            _logicUser = new UserOracleContext();
            _user = _logicUser.GetById(_post.GuestID);
            _logicMeida = new MediaOracleContext();
            _logicPost = new PostLogic();
            _logicGuest = new GuestLogic(new GuestOracleContext());
        }

        private void PostFeed_Load(object sender, EventArgs e)
        {
            lbReport1.Text = _post.Content;
            lblAuteurNaam.Text = _user.Name +@" "+ _user.Surname;
            lblDatum.Text = @"Geplaatst op "+_post.Date.ToString("dd/MM/yyyy");

            if (_post.MediaID != 0)
            {
                _media = _logicMeida.GetById(_post.MediaID);
                string dirDownloadedFiles = Path.GetDirectoryName(Application.ExecutablePath) + @"\downloaded_files\";
                string ftpPath = @"/" + _post.EventID + @"/" + _post.GuestID + @"/" + _media.Path;
                string localFilePath = dirDownloadedFiles + _media.Path;

                if (!File.Exists(dirDownloadedFiles)) Directory.CreateDirectory(dirDownloadedFiles);

                if (!File.Exists(localFilePath))
                {
                    // TODO: Betere manier om bestand op te halen?
                    if (FtpHelper.DownloadFile(ftpPath, localFilePath))
                    {
                        pbMediaMessage.ImageLocation = @localFilePath;
                        pbMediaMessage.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                }
                else
                {
                    pbMediaMessage.ImageLocation = @localFilePath;
                    pbMediaMessage.SizeMode = PictureBoxSizeMode.StretchImage;
                }

            }
            else
            {
                pbMediaMessage.Visible = false;
                lblDownloadMedia.Visible = false;
            }

        }

        private void lblDownloadMedia_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (_post.MediaID != 0)
            {
                _media = _logicMeida.GetById(_post.MediaID);
                string dirDownloadedFiles = Path.GetDirectoryName(Application.ExecutablePath) + @"\downloaded_files\";
                string localFilePath = new Uri(dirDownloadedFiles + _media.Path).AbsolutePath;
                SaveFileDialog saveMedia = new SaveFileDialog();
                saveMedia.FileName = _media.Name;
                if (saveMedia.ShowDialog() == DialogResult.OK)
                {
                    // ToDo: Bestand laten downloaden.
                }
            }
        }

        private void lbReport_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var reportForm = new ReportPostForm();
            var result = reportForm.ShowDialog();
            if (result == DialogResult.OK)
            {
                // try to add report to database and show appropriate message
                MessageBox.Show(_logicPost.Report(_logicGuest.GetGuestByEvent(_event, _user.ID), _post, reportForm.ReasonReturnValue)
                    ? "Rapport succesvol verzonden. Bedankt voor u feedback!"
                    : "Er is iets fout gegaan met het doorvoeren van dit rapport, onze excuses hiervoor.");
            }
        }
    }
}
