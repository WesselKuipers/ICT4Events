using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedModels.Models;

namespace SharedModels.Data.ContextInterfaces
{
    public interface IPostContext : IRepositoryContext<Post, int>
    {
        List<Post> GetAllByEvent(Event ev);
        List<Post> GetRepliesById(int id);
    }
}
