using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedModels.Models;

namespace SharedModels.Data.ContextInterfaces
{
    public interface IPostContext
    {
        List<Post> GetAllByEvent(Event ev);
        Post GetById(int id);
        List<Post> GetRepliesById(int id);
        Post Insert(Post post);
        bool Update(Post post);
        bool Delete(Post post);
    }
}
