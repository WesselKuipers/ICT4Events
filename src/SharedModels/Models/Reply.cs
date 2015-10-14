using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedModels.Models
{
    public class Reply : Post
    {
        public Post MainPost { get; }

        public Reply(int id, Guest guest, Media media, string content, Post mainPost) : base(id, guest, media, content)
        {
            MainPost = mainPost;
        }
    }
}
