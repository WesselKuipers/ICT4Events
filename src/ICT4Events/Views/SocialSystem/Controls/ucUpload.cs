using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using SharedModels.Logic;
using SharedModels.Models;

namespace ICT4Events.Views.SocialSystem.Controls
{
    public partial class UcUpload : UserControl
    {
        private readonly User _user;
        private readonly Event _event;
        public string Filepath;
        public  Media UploadedFile;

        public UcUpload(User user, Event ev)
        {
            InitializeComponent();
            _user = user;
            _event = ev;
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            var uploadFile = new OpenFileDialog
            {
                Title = "Media uploaden",
                Filter = "Image files|*.jpg;*.jpeg;*.jpe;*.jfif;*.png|Audio files|*.mp3|Video files|*.mp4"
            };
            string[] imageEx = { ".jpg", ".jpeg", ".jpe", ".jfif", ".png" };

            if (uploadFile.ShowDialog() != DialogResult.OK) return;
            Filepath = uploadFile.FileName;
            btnUpload.Text = Filepath;

            if (!imageEx.Contains(Path.GetExtension(Filepath))) return;
            pbPreview.ImageLocation = Filepath;
            pbPreview.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private void btBestandUploaden_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Filepath))
            {
                MessageBox.Show("Geen bestand geselecteerd!");
            }
            else
            {
                UploadedFile = LogicCollection.MediaLogic.UploadMedia(Filepath, _user, _event);
                    // Show errors
                if (UploadedFile != null)
                {
                    MessageBox.Show("Uw bestand is succesvol upgeload", "File successfully uploaded",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }
                else
                    MessageBox.Show("Er is iets misgegaan");
            }
         }
     }
}
