using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedModels.Enums;

namespace SharedModels.Models
{
    public class Post
    {
        public int ID { get; }
        public Guest Author { get; }
        public Media Media { get; set; }
        public string Content { get; set; }

        // TODO: Check if it's more desired to do a more accurate split like:
        // http://stackoverflow.com/questions/16725848/how-to-split-text-into-words
        public List<string> Tags => Content.Split(' ').Where(word => word.StartsWith("#")).ToList();

        public bool Visible { get; set; } = true;

        public Post(int id, Guest guest, Media media, string content)
        {
            ID = id;
            Author = guest;
            Media = media;
            Content = content;
        }
    }
}
