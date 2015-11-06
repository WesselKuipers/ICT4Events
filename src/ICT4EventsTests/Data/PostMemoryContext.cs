using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedModels.Data.ContextInterfaces;
using SharedModels.Models;

namespace ICT4EventsTests.Data
{
    public class PostMemoryContext : IPostContext
    {
        private List<Post> _posts = new List<Post>();
        private List<Reply> _replies = new List<Reply>();
        private List<KeyValuePair<int, int>> _likes = new List<KeyValuePair<int, int>>();

        public List<Post> GetAll()
        {
            return _posts;
        }

        public Post GetById(object id)
        {
            return _posts.FirstOrDefault(p => p.ID == (int)id);
        }

        public Post Insert(Post entity)
        {
            if (GetById(entity.ID) != null) return null;

            var id = _posts.Max(e => e.ID);
            var post = new Post(id, entity.GuestID, entity.EventID, entity.MediaID, entity.Date, entity.Visible, entity.Content);
            _posts.Add(post);

            return post;
        }

        public bool Update(Post entity)
        {
            var post = _posts.FirstOrDefault(e => e.ID == entity.ID);
            if (post == null) return false;

            _posts.Remove(post);
            _posts.Add(entity);
            return true;
        }

        public bool Delete(Post entity)
        {
            var post = _posts.FirstOrDefault(e => e.ID == entity.ID);
            if (post == null) return false;

            _posts.Remove(post);
            _posts.Add(entity);
            return true;
        }

        public Reply Insert(Reply entity)
        {
            if (GetById(entity.ID) != null) return null;

            var id = _posts.Max(e => e.ID);
            var reply = new Reply(id, entity.GuestID, entity.EventID, entity.MediaID, entity.MainPostID, entity.Date, entity.Visible, entity.Content);
            _replies.Add(reply);

            return reply;
        }

        public List<Post> GetAllByEvent(Event ev)
        {
            return _posts.Where(p => p.EventID == ev.ID).ToList();
        }

        public List<Reply> GetRepliesByPost(Post post)
        {
            return _replies.Where(r => r.MainPostID == post.ID).ToList();
        }

        public List<int> GetAllLikes(Post post)
        {
            return _likes.Where(x => x.Key == post.ID).Select(y=> y.Value).ToList();
        }

        public bool AddLikeToPost(Post post, int guestID)
        {
            throw new NotImplementedException();
        }

        public bool RemoveLikeFromPost(Post post, int guestID)
        {
            throw new NotImplementedException();
        }

        public bool AddLikeToPost(Post post, Guest guest)
        {
            if (_likes.Any(x => x.Key == post.ID && x.Value == guest.ID)) return false;

            _likes.Add(new KeyValuePair<int, int>(post.ID, guest.ID));
            return true;
        }

        public bool RemoveLikeFromPost(Post post, Guest guest)
        {
            var like = _likes.FirstOrDefault(x => x.Key == post.ID && x.Value == guest.ID);

            if (like.Equals(default(KeyValuePair<int, int>))) return false;

            _likes.Remove(like);
            return true;
        }

        public bool AddLikeToPost(Post post, User admin)
        {
            throw new NotImplementedException();
        }

        public bool RemoveLikeFromPost(Post post, User admin)
        {
            throw new NotImplementedException();
        }

        public List<Post> GetPostsByTag(string tag)
        {
            throw new NotImplementedException();
        }

        public List<string> GetTagsByPost(Post post)
        {
            throw new NotImplementedException();
        }

        public bool AddTagToPost(Post post, string tag)
        {
            throw new NotImplementedException();
        }

        public bool AddTagToEvent(Event ev, string tag)
        {
            throw new NotImplementedException();
        }

        public bool RemoveTagFromPost(Post post, string tag)
        {
            throw new NotImplementedException();
        }
    }
}
