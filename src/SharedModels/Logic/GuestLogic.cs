using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedModels.Data.ContextInterfaces;
using SharedModels.Models;

namespace SharedModels.Logic
{
    public class GuestLogic
    {
        private IGuestContext _context;

        public GuestLogic(IGuestContext context)
        {
            _context = context;
        }

        public int GetGuestCountByEvent(Event ev)
        {
            return _context.GetGuestCountByEvent(ev);
        }

        public Guest GetGuestByEvent(Event ev, int userID)
        {
            return _context.GetGuestByEvent(ev, userID);
        }

        public bool UpdateGuest(Guest guest)
        {
            return _context.Update(guest);
        }
    }
}
