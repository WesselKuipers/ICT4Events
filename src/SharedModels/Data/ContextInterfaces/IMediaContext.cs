using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedModels.Models;

namespace SharedModels.Data.ContextInterfaces
{
    public interface IMediaContext
    {
        List<Media> GetAllByUser(User user);
        Media GetById(int id);
        Media Insert(Media location);
        bool Update(Media location);
        bool Delete(Media location);
    }
}
