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
    }
}
