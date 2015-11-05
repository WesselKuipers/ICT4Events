using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedModels.Data.ContextInterfaces;
using SharedModels.Models;

namespace ICT4EventsTests.Data
{
    public class EventMemoryContext : IEventContext
    {
        private List<Event> _events = new List<Event>();

        public List<Event> GetAll()
        {
            return _events;
        }

        public Event GetById(object id)
        {
            return _events.FirstOrDefault(e => e.ID == (int) id);
        }

        public Event Insert(Event entity)
        {
            if (GetById(entity.ID) != null) return null;

            var id = _events.Max(e => e.ID);
            var ev = new Event(id, entity.Name, entity.StartDate, entity.EndDate, entity.Location, entity.MapPath,
                entity.MaxCapacity);
            _events.Add(ev);

            return ev;
        }

        public bool Update(Event entity)
        {
            var ev = _events.FirstOrDefault(e => e.ID == entity.ID);
            if (ev == null) return false;

            _events.Remove(ev);
            _events.Add(entity);
            return true;
        }

        public bool Delete(Event entity)
        {
            var ev = _events.FirstOrDefault(e => e.ID == entity.ID);
            if (ev == null) return false;

            _events.Remove(ev);
            return true;
        }

        public List<string> GetTagsByEvent(Event ev)
        {
            throw new NotImplementedException();
        }
    }
}
