using System.Collections.Generic;
using SharedModels.Models;

namespace SharedModels.Data.ContextInterfaces
{
    public interface IGuestContext
    {
        List<Guest> GetAllByEvent(Event ev);
        Guest Insert(Guest guest);
        bool Update(Guest guest);
        bool Delete(Guest guest);
    }
}