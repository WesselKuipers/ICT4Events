using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedModels.Data.ContextInterfaces;
using SharedModels.Models;

namespace ICT4EventsTests.Data
{
    public class GuestMemoryContext : IGuestContext
    {
        public List<Guest> GetAll()
        {
            throw new NotImplementedException();
        }

        public Guest GetById(object id)
        {
            throw new NotImplementedException();
        }

        public Guest Insert(Guest entity)
        {
            throw new NotImplementedException();
        }

        public bool Update(Guest entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Guest entity)
        {
            throw new NotImplementedException();
        }

        public List<Guest> GetAllByEvent(Event ev)
        {
            throw new NotImplementedException();
        }

        public Guest GetGuestByEvent(Event ev, int userID)
        {
            throw new NotImplementedException();
        }

        public List<Guest> GetGuestsByUser(User user)
        {
            throw new NotImplementedException();
        }

        public List<Guest> GetGuestsByGroup(Event ev, int leaderID)
        {
            throw new NotImplementedException();
        }

        public Guest GetByRfid(string rfid)
        {
            throw new NotImplementedException();
        }

        public int GetGuestCountByEvent(Event ev)
        {
            throw new NotImplementedException();
        }

        public int GetGuestCountByLocation(Location location)
        {
            throw new NotImplementedException();
        }
    }
}
