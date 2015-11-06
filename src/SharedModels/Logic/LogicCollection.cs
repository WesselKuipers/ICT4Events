using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedModels.Data.OracleContexts;

namespace SharedModels.Logic
{
    /// <summary>
    /// Helper class used for accessing the user logic globally
    /// Currently defaults to using Oracle contexts
    /// </summary>
    public static class LogicCollection
    {
        private static UserLogic _userLogic;
        public static UserLogic UserLogic => _userLogic ?? (_userLogic = new UserLogic(new UserOracleContext()));

        private static GuestLogic _guestLogic;
        public static GuestLogic GuestLogic => _guestLogic ?? (_guestLogic = new GuestLogic(new GuestOracleContext()));

        private static EventLogic _eventLogic;
        public static EventLogic EventLogic => _eventLogic ?? (_eventLogic = new EventLogic(new EventOracleContext()));

        private static LocationLogic _locationLogic;
        public static LocationLogic LocationLogic => _locationLogic ?? (_locationLogic = new LocationLogic(new LocationOracleContext()));

        private static PostLogic _postLogic;
        public static PostLogic PostLogic => _postLogic ?? (_postLogic = new PostLogic(new PostOracleContext()));

        private static PostLogic _materialLogic;
        public static PostLogic MaterialLogic => _postLogic ?? (_materialLogic = new PostLogic(new PostOracleContext()));
    }
}
