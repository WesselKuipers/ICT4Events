using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedModels.Data.ContextInterfaces;
using SharedModels.Data.OracleContexts;
using SharedModels.Models;

namespace SharedModels.Logic
{
    public class PostLogic
    {
        private readonly IPostContext _context;

        public PostLogic()
        {
            _context = new PostOracleContext();
        }

        public PostLogic(IPostContext context)
        {
            _context = context;
        }

        public Post InsertPost(Post post)
        {
            return _context.Insert(post);
        }

        public bool UpdatePost(Post post)
        {
            return _context.Update(post);
        }

        public bool DeletePost(Post post)
        {
            return _context.Delete(post);
        }

        public List<Post> GetAllByEvent(Event ev)
        {
            return _context.GetAllByEvent(ev);
        }

        public List<Reply> GetRepliesByPost(Post post)
        {
            return _context.GetRepliesByPost(post);
        }
    }
}
