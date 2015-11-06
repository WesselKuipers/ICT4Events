using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedModels.Data.ContextInterfaces;
using SharedModels.Data.OracleContexts;
using SharedModels.Models;

namespace SharedModels.Logic
{
    public class MediaLogic
    {
        private IMediaContext _context;

        public MediaLogic()
        {
            _context = new MediaOracleContext();
        }

        public MediaLogic(IMediaContext context)
        {
            _context = context;
        }

        public List<Media> GetAllByGuest(Guest guest)
        {
            return _context.GetAllByGuest(guest);
        }
    }
}
