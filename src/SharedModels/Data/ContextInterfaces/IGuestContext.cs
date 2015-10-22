using System.Collections.Generic;
using SharedModels.Models;

namespace SharedModels.Data.ContextInterfaces
{
    public interface IGuestContext : IRepositoryContext<Guest>
    {
        List<Guest> GetByEvent(Event ev);
    }
}