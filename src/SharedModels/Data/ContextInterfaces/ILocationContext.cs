using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedModels.Models;

namespace SharedModels.Data.ContextInterfaces
{
    public interface ILocationContext
    {
        List<Location> GetAllByEvent(Event ev);
        Location GetById(int id);
        Location Insert(Location location);
        bool Update(Location location);
        bool Delete(Material location);
    }
}
