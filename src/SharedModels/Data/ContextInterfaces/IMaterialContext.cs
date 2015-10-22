using System;
using System.Collections.Generic;
using SharedModels.Models;

namespace SharedModels.Data.ContextInterfaces
{
    public interface IMaterialContext : IRepositoryContext<Material>
    {
        List<Material> GetAllByEvent(Event ev);
        Material AddReservation(Material material, int guestID, DateTime startDate, DateTime endDate);
        bool UpdateReservation(Material material, DateTime startDate, DateTime endDate);
        bool RemoveReservation(Material material);
    }
}