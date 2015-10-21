using System.Collections.Generic;
using SharedModels.Models;

namespace SharedModels.Data.ContextInterfaces
{
    public interface IMaterialContext : IRepositoryContext<Material, int>
    {
        List<Material> GetAllByEvent(Event ev);
    }
}