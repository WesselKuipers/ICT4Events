using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedModels.Models;

namespace SharedModels.Data.ContextInterfaces
{
    public interface IMediaContext : IRepositoryContext<Media, int>
    {
        List<Media> GetAllByGuest(Guest guest);
    }
}
