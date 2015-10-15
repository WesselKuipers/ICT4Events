using System.Collections.Generic;
using SharedModels.Models;

namespace SharedModels.Data.ContextInterfaces
{
    public interface IMaterialContext
    {
        List<Material> GetAllByEvent(Event ev);
        Material GetById(int id);
        Material Insert(Material material);
        bool Update(Material material);
        bool Delete(Material material);
    }
}