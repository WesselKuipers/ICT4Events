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

        private MakePost(Event ev)
        {
            InitializeComponent();
            _event = ev;
            _logicMedia = new MediaOracleContext();
            _logicPost = new PostLogic(new PostOracleContext());
        }

        /// <summary>
        /// Constructor used for the post form for users
        /// </summary>
        /// <param name="user">The user who is placing this post</param>
        /// <param name="ev">The event this post belongs to</param>
        public MakePost(Guest user, Event ev) : this(ev)
        {
            _user = user;
        }
        /// <summary>
        /// Constructor used for the post form for administrators
        /// </summary>
        /// <param name="admin">The user who is placing this post</param>
        /// <param name="ev">The event this post belongs to</param>
        public MakePost(User admin, Event ev) : this(ev)
        {
            _admin = admin;
        }

        /// <summary>
        /// opens file dialog to select the file to upload
        /// TODO: Filter is not working correctly
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btUploaden_Click(object sender, EventArgs e)
        {
            var uploadFile = new OpenFileDialog
            {
                Title = "Media uploaden",
                Filter = "Image files|*.jpg;*.jpeg;*.jpe;*.jfif;*.png|Audio files|*.mp3|Video files|*.mp4"
            };
            string[] imageEx = { ".jpg", ".jpeg", ".jpe", ".jfif", ".png" };

            if (uploadFile.ShowDialog() != DialogResult.OK) return;
            _filepath = uploadFile.FileName;
            btnUpload.Text = _filepath;

            if (!imageEx.Contains(Path.GetExtension(_filepath))) return;
            pbPreview.ImageLocation = @_filepath;
            pbPreview.SizeMode = PictureBoxSizeMode.Zoom;
        }

        /// <summary>
        /// Uploads a file to the FTP server
        /// </summary>
        private void btBestandUploaden_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(_filepath))
            {
                MessageBox.Show(@"Geen bestand geselecteerd!");
            }
            else
            {
                // Set file variables
                var ftpFileName = Path.GetFileName(_filepath);
                var ftpFileExtension = Path.GetExtension(_filepath);
                var ftpFileNameWithoutExtension = Path.GetFileNameWithoutExtension(_filepath);

                if (_user != null)
                {
                    // TODO: Refactor to have less duplicate code. Move these to separate functions!
                    
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

                    if (!FtpHelper.UploadFile(_filepath, _event.ID + "/" + _user.ID + "/" + ftpFileName)) return;

                    // Check file extension
                    var type = CheckExtension(ftpFileExtension);
                        
                    // Makes the object media
                    var media = new Media(0, _user.ID, _event.ID, type, ftpFileNameWithoutExtension,
                        ftpFileExtension, ftpFileName);
                    _uploadedFile = _logicMedia.Insert(media);

                    // Show errors
                    if (_uploadedFile != null)
                        MessageBox.Show("Uw bestand is succesvol upgeload", "File successfully uploaded", MessageBoxButtons.OK,
                            MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    else
                        MessageBox.Show("Er is iets misgegaan");
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

                    if (!FtpHelper.UploadFile(_filepath, _event.ID + "/" + _admin.ID + "/" + ftpFileName)) return;

                    // Check file extension
                    var type = CheckExtension(ftpFileExtension);

                    // Makes the object media
                    var media = new Media(0, _admin.ID, _event.ID, type, ftpFileNameWithoutExtension,
                        ftpFileExtension, ftpFileName);
                    _uploadedFile = _logicMedia.Insert(media);

                    // Show errors
                    if (_uploadedFile != null)
                        MessageBox.Show("Uw bestand is succesvol geüpload", "File successfully uploaded", MessageBoxButtons.OK,
                            MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    else
                        MessageBox.Show("Er is iets misgegaan");
                }
            }
        }
        /// <summary>
        /// Creates a post adds it to database
        /// </summary>
        private void btPostAanmaken_Click(object sender, EventArgs e)
        {
            // Check if message is empty
            if (string.IsNullOrEmpty(tbBerichtPost.Text))
            {
                MessageBox.Show("Ga je echt niets vertellen?");
            }
            else
            {
                // Check if chosen file is uploaded
                if (!string.IsNullOrEmpty(_filepath) && (_uploadedFile == null))
                {
                    MessageBox.Show("Eerst uploaden voor het posten.");
                }
                else
                {
                    Post addedPost = null;
                    if (string.IsNullOrEmpty(_filepath))
                    {
                        if (_user != null)
                        {
                            // Guest makes post without media
                            var p = new Post(0, _user.ID, _event.ID, 0, DateTime.Now, true, tbBerichtPost.Text);
                            addedPost = _logicPost.InsertPost(p);
                        }
                        else
                        {
                            // Admin makes post without media
                            var p = new Post(0, _admin.ID, _event.ID, 0, DateTime.Now, true, tbBerichtPost.Text);
                            addedPost = _logicPost.InsertPost(p);
                        }
                        
                    }
                    else
                    {
                        if (_uploadedFile != null)
                        {
                            addedPost = _logicPost.InsertPost(_user != null
                                ? new Post(0, _user.ID, _event.ID, _uploadedFile.ID, DateTime.Now, true, tbBerichtPost.Text)
                                : new Post(0, _admin.ID, _event.ID, _uploadedFile.ID, DateTime.Now, true, tbBerichtPost.Text));
                        }
                    }

                    // List of tags
                    if (addedPost != null)
                    {
                        foreach (var tag in addedPost.Tags)
                        {
                            _logicPost.AddTagToEvent(_event, tag.ToLower());
                            _logicPost.AddTagToPost(addedPost, tag.ToLower());
                        }
                    }
                    else
                    {
                        MessageBox.Show("Er is iets misgegaan bij het toevoegen");
                        return;
                    }

                    MessageBox.Show("Je bericht is gepubliceerd op je tijdlijn");
                }
            }
        }
        /// <summary>
        /// Checks the extension of the file and returns the mediatype
        /// </summary>
        /// <param name="ftpFileExtension">Extension to check</param>
        /// <returns>The appropriate mediatype belonging to the specified file extension</returns>
        private MediaType CheckExtension(string ftpFileExtension)
        {
            string[] imageEx = { ".jpg", ".jpeg", ".jpe", ".jfif", ".png" };
            string[] audioEx = { ".wav", ".mp3" };
            string[] videoEx = { ".mp4" };

            var type = MediaType.Image;
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
