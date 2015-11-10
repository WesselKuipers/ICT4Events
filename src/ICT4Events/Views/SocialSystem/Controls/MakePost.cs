using System;
using System.Linq;
using System.Windows.Forms;
using ICT4Events.Views.SocialSystem.Forms;
using SharedModels.Data.OracleContexts;
using SharedModels.FTP;
using SharedModels.Logic;
using SharedModels.Models;

namespace ICT4Events.Views.SocialSystem.Controls
{
    public partial class MakePost : UserControl
    {
        private readonly User _user;
        private readonly Event _event;
        private readonly PostLogic _logicPost;
        private readonly UcUpload _uploadedMedia;

        /// <summary>
        /// Constructor used for the post form for users
        /// </summary>
        /// <param name="user">The user who is placing this post</param>
        /// <param name="ev">The event this post belongs to</param>
        public MakePost(User user, Event ev)
        {
            _user = user;
            InitializeComponent();
            _event = ev;
            _logicPost = new PostLogic(new PostOracleContext());

            _uploadedMedia = new UcUpload(_user, _event);
            tbpLoadUcUpload.Controls.Add(_uploadedMedia);
            LoadMediaList();
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
                if (!string.IsNullOrEmpty(_uploadedMedia.Filepath) && (_uploadedMedia.UploadedFile == null))
                {
                    MessageBox.Show("Eerst uploaden voor het posten.");
                }
                else
                {
                    Post addedPost = null;
                    if (string.IsNullOrEmpty(_uploadedMedia.Filepath))
                    {
                        var media = (Media)cmbOwnMedia.SelectedItem;
                        Post p;
                        if (media == null)
                        {
                            // Post without media
                            p = new Post(0, _user.ID, _event.ID, 0, DateTime.Now, true, tbBerichtPost.Text);
                        }
                        else
                        {
                            p = new Post(0, _user.ID, _event.ID, media.ID, DateTime.Now, true, tbBerichtPost.Text);
                        }
                        addedPost = _logicPost.InsertPost(p);

                    }
                    else if(!string.IsNullOrEmpty(_uploadedMedia.Filepath))
                    {
                        // Post with media
                        if (_uploadedMedia.UploadedFile != null)
                        {
                            addedPost = _logicPost.InsertPost(new Post(0, _user.ID, _event.ID, _uploadedMedia.UploadedFile.ID, DateTime.Now, true, tbBerichtPost.Text));
                        }
                    }

                    // List of tags
                    if (addedPost != null)
                    {
                        foreach (var tag in addedPost.Tags)
                        {
                            _logicPost.AddTagToPost(addedPost, tag.ToLower());
                        }
                        MessageBox.Show("Je bericht is gepubliceerd op je tijdlijn");
                    }
                    else
                    {
                        MessageBox.Show("Je bericht is niet gepubliceerd op de tijdlijn");
                    }

                }
            }
        }
        /// <summary>
        /// Loads the media list of the catalogue from the user
        /// </summary>
        private void LoadMediaList()
        {
            cmbOwnMedia.Items.Clear();
            var mediaList = LogicCollection.MediaLogic.GetAllMedia(_event).Where(x => x.UserID == _user.ID);
            if (!mediaList.Any())
            {
                cmbOwnMedia.Enabled = false;
                return;
            }
            foreach (var media in mediaList)
            {
                cmbOwnMedia.Items.Add(media);
            }
        }
        private void cmbOwnMedia_SelectionChangeCommitted(object sender, EventArgs e)
        {
            var selectedMedia = (Media) cmbOwnMedia.SelectedItem;
            if (selectedMedia != null)
            {
                _uploadedMedia.pbPreview.ImageLocation = $"{FtpHelper.ServerHardLogin}/{_event.ID}/{_user.ID}/{selectedMedia.Path}";
            }
        }

        private void btnRefreshOwnMediaList_Click(object sender, EventArgs e)
        {
            LoadMediaList();
        }
    }
}
