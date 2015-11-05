using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedModels.Data.ContextInterfaces;
using SharedModels.Models;

namespace ICT4EventsTests.Data
{
    public class LocationMemoryContext : ILocationContext
    {
        private List<Location> _locations = new List<Location>();

        public List<Location> GetAll()
        {
            return _locations;
        }

        public Location GetById(object id)
        {
            return _locations.FirstOrDefault(l => l.ID == (int) id);
        }

        public Location Insert(Location entity)
        {
            if (GetById(entity.ID) != null) return null;

            var id = _locations.Max(e => e.ID);
            var location = new Location(id, entity.EventID, entity.Name, entity.Capacity, entity.Price, entity.Coordinates);
            _locations.Add(location);

            return location;
        }

        public bool Update(Location entity)
        {
            var location = _locations.FirstOrDefault(e => e.ID == entity.ID);
            if (location == null) return false;

            _locations.Remove(location);
            _locations.Add(entity);
            return true;
        }

        public bool Delete(Location entity)
        {
            var location = _locations.FirstOrDefault(e => e.ID == entity.ID);
            if (location == null) return false;

            _locations.Remove(location);
            return true;
        }

        public List<Location> GetAllByEvent(Event ev)
        {
            return _locations.Where(l => l.EventID == ev.ID).ToList();
        }
    }
}
