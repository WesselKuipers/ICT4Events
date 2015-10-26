using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedModels.Data.ContextInterfaces;
using SharedModels.Models;

namespace SharedModels.Logic
{
    public class EventLogic
    {
        private readonly IEventContext _context;

        public EventLogic(IEventContext context)
        {
            _context = context;
        }

        public List<Event> GetAllEvents()
        {
            return _context.GetAll();
        }
    }
}
