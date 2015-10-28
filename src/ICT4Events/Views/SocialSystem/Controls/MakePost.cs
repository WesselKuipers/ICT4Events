using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Security;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using SharedModels.Data.OracleContexts;
using SharedModels.Enums;
using SharedModels.FTP;
using SharedModels.Models;

namespace ICT4Events.Views.SocialSystem.Controls
{
    public partial class MakePost : UserControl
    {
        private readonly User _user;
        private readonly Event _event;
        private readonly MediaOracleContext _logicMedia;
        private readonly PostOracleContext _logicPost;
        private string _filepath;
        private Media _uploadedFile;

        public MakePost(User user, Event ev)
        {
            InitializeComponent();
            _user = user;
            _event = ev;
            _logicMedia = new MediaOracleContext();
            _logicPost = new PostOracleContext();

        }

        /// <summary>
        /// OPEN FILE DIALOG TO SELECT FILE
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btUploaden_Click(object sender, EventArgs e)
        {
            OpenFileDialog uploadFile = new OpenFileDialog();
            uploadFile.Title = @"Media uploaden";
            uploadFile.Filter = @"Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png | Audio files (*.wav, *mp3) | *.wav; *.mp3 | Video files (*.mp4) | *.mp4";

            if (uploadFile.ShowDialog() != DialogResult.OK) return;
            _filepath = uploadFile.FileName;
            btUploaden.Text = _filepath;
            pbPreview.ImageLocation = @_filepath;
            pbPreview.SizeMode = PictureBoxSizeMode.StretchImage;
        }
        /// <summary>
        /// UPLOAD TO FTP SERVER
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btBestandUploaden_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(_filepath))
            {
                MessageBox.Show(@"Geen bestand geselecteerd!");
            }
            else
            {
                // Set file variables
                string ftpFileName = Path.GetFileName(_filepath);
                string ftpFileExtension = Path.GetExtension(_filepath);
                string ftpFileNameWithoutExtension = Path.GetFileNameWithoutExtension(_filepath);

                if (!File.Exists(FtpHelper.ServerAddress + "/" + _event.ID))
                {
                    FtpHelper.CreateDirectory(_event.ID.ToString());
                    if (!File.Exists(FtpHelper.ServerAddress + "/" + _event.ID + "/" + _user.ID))
                    {
                        FtpHelper.CreateDirectory(_event.ID + "/" + _user.ID);
                    }
                }

                if (FtpHelper.UploadFile(_filepath, _event.ID + "/" + _user.ID + "/" + ftpFileName))
                {
                    string[] imageEx = { ".jpg", ".jpeg", ".jpe", ".jfif", ".png" };
                    string[] audioEx = { ".wav", ".mp3" };
                    string[] videoEx = { ".mp4" };

                    MediaType type = MediaType.Image;
                    if (imageEx.Contains(ftpFileExtension))
                    {
                        type = MediaType.Image;
                    }
                    else if (audioEx.Contains(ftpFileExtension))
                    {
                        type = MediaType.Audio;
                    }
                    else if (videoEx.Contains(ftpFileExtension))
                    {
                        type = MediaType.Video;
                    }

                    MessageBox.Show(@"Uw bestand is succesvol upgeload", @"Message", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    Media media = new Media(0, _user.ID, _event.ID, type, ftpFileNameWithoutExtension, ftpFileExtension, ftpFileName);
                    _uploadedFile = _logicMedia.Insert(media);
                }
            }
        }

        /// <summary>
        /// MAKING AND ADDING POST TO DATABASE
        /// TODO: POSTHASH UIT BERICHT FILTEREN EN OPSLAAN IN DATABASE
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btPostAanmaken_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbBerichtPost.Text))
            {
                MessageBox.Show(@"Ga je echt niets vertellen? Kom op joh.");
            }
            else
            {
                if (!string.IsNullOrEmpty(_filepath) && (_uploadedFile == null))
                {
                    MessageBox.Show(@"Eerst uploaden voor het posten.");
                }
                else
                {
                    // Filter tags out of message
                    var regex = new Regex(@"(?<=#)\w+");
                    var matches = regex.Matches(tbBerichtPost.Text);

                    if (string.IsNullOrEmpty(_filepath))
                    {
                        Post p = new Post(0, _user.ID, _event.ID, 0, DateTime.Now, true, tbBerichtPost.Text);
                        _logicPost.Insert(p);
                    }
                    else
                    {
                        if (_uploadedFile != null)
                        {
                            Post p = new Post(0, _user.ID, _event.ID, _uploadedFile.ID, DateTime.Now, true,
                                tbBerichtPost.Text);
                            _logicPost.Insert(p);
                        }
                    }

                    MessageBox.Show(@"Je bericht is gepubliceerd op je tijdlijn");
                }
            }
        }
    }
}
