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
        Reply Insert(Reply entity);
        List<Post> GetAllByEvent(Event ev);
        List<Reply> GetRepliesByPost(Post post);
        List<int> GetAllLikes(Post post);
        bool AddLikeToPost(Post post, Guest guest);
        bool RemoveLikeFromPost(Post post, Guest guest);
    }
}
