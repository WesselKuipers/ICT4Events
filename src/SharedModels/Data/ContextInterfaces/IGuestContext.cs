using System.Collections.Generic;
using SharedModels.Models;

namespace SharedModels.Data.ContextInterfaces
{
    public interface IGuestContext : IRepositoryContext<Guest>
    {
        List<Guest> GetAllByEvent(Event ev);
        Guest GetGuestByEvent(Event ev, int userID);
        int GetGuestCountByEvent(Event ev);
        int GetGuestCountByLocation(Location location);
    }
}