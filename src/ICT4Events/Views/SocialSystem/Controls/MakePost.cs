using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using SharedModels.Data.ContextInterfaces;
using SharedModels.Data.OracleContexts;
using SharedModels.Enums;
using SharedModels.FTP;
using SharedModels.Logic;
using SharedModels.Models;

namespace ICT4Events.Views.SocialSystem.Controls
{
    public partial class MakePost : UserControl
    {
        private readonly Guest _user;
        private readonly User _admin;
        private readonly Event _event;
        private readonly IMediaContext _logicMedia;
        private readonly PostLogic _logicPost;
        private string _filepath;
        private Media _uploadedFile;

        /// <summary>
        /// This is an guest
        /// </summary>
        /// <param name="user"></param>
        /// <param name="ev"></param>
        public MakePost(Guest user, Event ev)
        {
            InitializeComponent();
            _user = user;
            _event = ev;
            _logicMedia = new MediaOracleContext();
            _logicPost = new PostLogic(new PostOracleContext());

        }
        /// <summary>
        /// this is an admin
        /// </summary>
        /// <param name="admin"></param>
        /// <param name="ev"></param>
        public MakePost(User admin, Event ev)
        {
            InitializeComponent();
            _admin = admin;
            _event = ev;
            _logicMedia = new MediaOracleContext();
            _logicPost = new PostLogic(new PostOracleContext());

        }

        /// <summary>
        /// opens file dialog to select the file to upload
        /// TODO: Filter is not working correctly
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btUploaden_Click(object sender, EventArgs e)
        {
            OpenFileDialog uploadFile = new OpenFileDialog();
            uploadFile.Title = @"Media uploaden";
            uploadFile.Filter = @"Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png | Audio files (*.wav, *.mp3) | *.wav; *.mp3 | Video files (*.mp4) | *.mp4 | All Files | *.* ";
            string[] imageEx = { ".jpg", ".jpeg", ".jpe", ".jfif", ".png" };

            if (uploadFile.ShowDialog() != DialogResult.OK) return;
            _filepath = uploadFile.FileName;
            btUploaden.Text = _filepath;
            if (imageEx.Contains(Path.GetExtension(_filepath)))
            {
                pbPreview.ImageLocation = @_filepath;
                pbPreview.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }
        /// <summary>
        /// uploads the file to the ftp server
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

                if (_user != null)
                {
                    // REMEMBER: BELOW IS A GUEST
                    if (!File.Exists(FtpHelper.ServerAddress + "/" + _event.ID))
                    {
                        // Creates user & event map if not exsist on FTP server
                        FtpHelper.CreateDirectory(_event.ID.ToString());
                        if (!File.Exists(FtpHelper.ServerAddress + "/" + _event.ID + "/" + _user.ID))
                        {
                            FtpHelper.CreateDirectory(_event.ID + "/" + _user.ID);
                        }
                    }

                    if (FtpHelper.UploadFile(_filepath, _event.ID + "/" + _user.ID + "/" + ftpFileName))
                    {
                        // Check file extension
                        MediaType type = CheckExtension(ftpFileExtension);
                        
                        // Makes the object media
                        Media media = new Media(0, _user.ID, _event.ID, type, ftpFileNameWithoutExtension,
                            ftpFileExtension, ftpFileName);
                        _uploadedFile = _logicMedia.Insert(media);

                        // Show errors
                        if (_uploadedFile != null)
                            MessageBox.Show(@"Uw bestand is succesvol upgeload", @"Message", MessageBoxButtons.OK,
                                MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                        else
                            MessageBox.Show(@"Er is iets misgegaan");
                    }
                }
                else
                {
                    // REMEMBER: BELOW IS A ADMIN
                    if (!File.Exists(FtpHelper.ServerAddress + "/" + _event.ID))
                    {
                        // Creates user & event map if not exsist on FTP server
                        FtpHelper.CreateDirectory(_event.ID.ToString());
                        if (!File.Exists(FtpHelper.ServerAddress + "/" + _event.ID + "/" + _admin.ID))
                        {
                            FtpHelper.CreateDirectory(_event.ID + "/" + _admin.ID);
                        }
                    }

                    if (FtpHelper.UploadFile(_filepath, _event.ID + "/" + _admin.ID + "/" + ftpFileName))
                    {
                        // Check file extension
                        MediaType type = CheckExtension(ftpFileExtension);

                        // Makes the object media
                        Media media = new Media(0, _admin.ID, _event.ID, type, ftpFileNameWithoutExtension,
                            ftpFileExtension, ftpFileName);
                        _uploadedFile = _logicMedia.Insert(media);

                        // Show errors
                        if (_uploadedFile != null)
                            MessageBox.Show(@"Uw bestand is succesvol upgeload", @"Message", MessageBoxButtons.OK,
                                MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                        else
                            MessageBox.Show(@"Er is iets misgegaan");
                    }
                }
            }
        }
        /// <summary>
        /// Making post & adding post to database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btPostAanmaken_Click(object sender, EventArgs e)
        {
            // Check if message is empty
            if (string.IsNullOrEmpty(tbBerichtPost.Text))
            {
                MessageBox.Show(@"Ga je echt niets vertellen? Kom op joh.");
            }
            else
            {
                // Check if chosen file is uploaded
                if (!string.IsNullOrEmpty(_filepath) && (_uploadedFile == null))
                {
                    MessageBox.Show(@"Eerst uploaden voor het posten.");
                }
                else
                {
                    Post addedPost = null;
                    if (string.IsNullOrEmpty(_filepath))
                    {
                        if (_user != null)
                        {
                            // guest makes post without media
                            Post p = new Post(0, _user.ID, _event.ID, 0, DateTime.Now, true, tbBerichtPost.Text);
                            addedPost = _logicPost.InsertPost(p);
                        }
                        else
                        {
                            // Admin makes post without media
                            Post p = new Post(0, _admin.ID, _event.ID, 0, DateTime.Now, true, tbBerichtPost.Text);
                            addedPost = _logicPost.InsertPost(p);
                        }
                        
                    }
                    else
                    {
                        if (_uploadedFile != null)
                        {

                            if (_user != null)
                            {
                                // Guest makes post with media
                                Post p = new Post(0, _user.ID, _event.ID, _uploadedFile.ID, DateTime.Now, true, tbBerichtPost.Text);
                                addedPost = _logicPost.InsertPost(p);
                            }
                            else
                            {
                                // Admin makes post with media
                                Post p = new Post(0, _admin.ID, _event.ID, _uploadedFile.ID, DateTime.Now, true, tbBerichtPost.Text);
                                addedPost = _logicPost.InsertPost(p);
                            }
                        }
                    }

                    // List of tags
                    if (addedPost != null)
                    {
                        foreach (string tag in addedPost.Tags)
                        {
                            _logicPost.AddTagToEvent(_event, tag.ToLower());
                            _logicPost.AddTagToPost(addedPost, tag.ToLower());
                        }
                    }
                    else
                    {
                        MessageBox.Show(@"Er is iets misgegaan bij het toevoegen");
                        return;
                    }


                    MessageBox.Show(@"Je bericht is gepubliceerd op je tijdlijn");
                }
            }
        }
        /// <summary>
        /// Checks the extension of the file and returns the mediatype
        /// </summary>
        /// <param name="ftpFileExtension"></param>
        /// <returns></returns>
        private MediaType CheckExtension(string ftpFileExtension)
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

            return type;
        }
    }
}
