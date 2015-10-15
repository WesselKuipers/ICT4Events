using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedModels.Models;

namespace SharedModels.Data.ContextInterfaces
{
    public interface IEventContext
    {
        List<Event> GetAll();
        Event GetById(int id);
        Event Insert(Event ev);
        bool Update(Event ev);
        bool Delete(Event ev);
    }
}
