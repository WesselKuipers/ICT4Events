using System;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using SharedModels.Data.OracleContexts;
using SharedModels.FTP;
using SharedModels.Models;

namespace ICT4Events.Views.SocialSystem.Controls
{
    public partial class PostFeed : UserControl
    {
        private readonly Post _post;
        private readonly User _user;
        private Media _media;
        private readonly UserOracleContext _logicUser;
        private readonly MediaOracleContext _logicMeida;

        public PostFeed(Post post)
        {
            InitializeComponent();
            _post = post;
            _logicUser = new UserOracleContext();
            _user = _logicUser.GetById(_post.GuestID);
            _logicMeida = new MediaOracleContext();
        }

        private void PostFeed_Load(object sender, EventArgs e)
        {
            lblPostMessage.Text = _post.Content;
            lblAuteurNaam.Text = _user.Name +@" "+ _user.Surname;
            lblDatum.Text = @"Geplaatst op "+_post.Date.ToString("dd/MM/yyyy");

            if (_post.MediaID != 0)
            {
                string dirFileDown = Path.GetDirectoryName(Application.ExecutablePath) + @"\downloaded_files\";

                _media = _logicMeida.GetById(_post.MediaID);
                Directory.CreateDirectory(dirFileDown);

                FtpHelper.DownloadFile(@"/" + _post.EventID + @"/" + _post.GuestID + @"/" + _media.Path, dirFileDown + _media.Path);
                string p1 = new Uri(dirFileDown + _media.Path).AbsolutePath;
                string p2 = new Uri(dirFileDown + _media.Path).LocalPath;
                pbMediaMessage.ImageLocation = new Uri(dirFileDown + _media.Path).LocalPath;
                pbMediaMessage.SizeMode = PictureBoxSizeMode.StretchImage;
           }

        }
    }
}
