using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedModels.Models;

namespace SharedModels.Data.ContextInterfaces
{
    public interface IPostContext : IRepositoryContext<Post>
    {
        List<Post> GetAllByEvent(Event ev);
        List<Reply> GetRepliesByPost(Post post);

        List<int> GetAllLikes(Post post);
        bool AddLikeToPost(Post post, Guest guest);
        bool RemoveLikeFromPost(Post post, Guest guest);

        List<Post> GetPostsByTag(string tag);
        List<string> GetTagsByPost(Post post);
        bool AddTagToPost(Post post, string tag);
        bool RemoveTagFromPost(Post post, string tag);
    }
}
