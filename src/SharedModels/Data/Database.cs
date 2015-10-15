using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.DataAccess;
using Oracle.DataAccess.Client;

namespace SharedModels.Data
{
    // TODO: Implement IDisposable, test using VPN
    // Probably requires a wrapper for that
    // http://i.imgur.com/NYSyRMr.png Local connection example
    public class Database
    {
        private static readonly string _connectionString = "User Id=dbi333426;Password=d5igdqmqdY;Server=fhictora01.fhict.local";
        //private static readonly string _connectionString = "User Id=ICT4Events;Password=wessel;Data Source=127.0.0.1";

        private static OracleConnection _connection;

        public static OracleConnection Connection
        {
            get
            {
                if (_connection == null || _connection.State != ConnectionState.Open)
                {
                    Connect();
                }

                return _connection;
            }
        }

        private static void Connect()
        {
            _connection = new OracleConnection { ConnectionString = _connectionString };
            _connection.Open();
        }

        private static void Close()
        {
            _connection.Close();
            _connection.Dispose();
        }
    }
}
