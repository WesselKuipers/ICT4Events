using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.DataAccess;
using Oracle.DataAccess.Client;
using SharedModels.Debug;

namespace SharedModels.Data
{
    public class Database
    {
        //private static readonly string _connectionString = "User Id=dbi333426;Password=d5igdqmqdY;Data Source=fhictora01.fhict.local/fhictora"; // Oracle DB on Athena
        //private static readonly string _connectionString = "User Id=ICT4Events;Password=wessel;Data Source=127.0.0.1"; // Oracle XE connection
        private static readonly string _connectionString = "User Id=ICT4Events;Password=ICT4Events;Data Source=//192.168.20.221:1521/xe"; // Oracle DB on InfraLab

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
            try
            {
                _connection.Open();
            }
            catch (OracleException e)
            {
                Logger.Write(e.Message);
            }
        }

        public static List<List<string>> ExecuteReader(string query, List<OracleParameter> args = null)
        {
            var result = new List<List<string>>();

            try
            {
                using (var con = new OracleCommand(query, Connection))
                {
                    if (args != null)
                    {
                        foreach (var arg in args)
                        {
                            con.Parameters.Add(arg);
                        }
                    }

                    var queryResult = con.ExecuteReader();
                    while (queryResult.Read())
                    {
                        var record = new string[queryResult.FieldCount];
                        for (var i = 0; i < queryResult.FieldCount; i++)
                        {
                            var val = queryResult.GetValue(i).ToString();
                            record[i] = !string.IsNullOrEmpty(val) ? val : "0";
                            //record[i] = queryResult.GetValue(i).ToString();
                        }

                        result.Add(record.ToList());
                    }
                }
            }
            catch (OracleException e)
            {
                Logger.Write(e.Message);
                return null;
            }
            finally
            {
                Close();
            }

            return result;
        }
       
        public static List<Dictionary<string, string>> ExecuteReaderDict(string query, List<OracleParameter> args = null)
        {
            var result = new List<Dictionary<string, string>>();

            try
            {
                using (var con = new OracleCommand(query, Connection))
                {
                    if (args != null)
                    {
                        foreach (var arg in args)
                        {
                            con.Parameters.Add(arg);
                        }
                    }

                    var queryResult = con.ExecuteReader();

                    while (queryResult.Read())
                    {
                        var record = new Dictionary<string, string>();
                        for (var i = 0; i < queryResult.FieldCount; i++)
                        {
                            record[queryResult.GetName(i)] = queryResult.GetValue(i).ToString();
                        }

                        result.Add(record);
                    }
                }
            }
            catch (OracleException e)
            {
                Logger.Write(e.Message);
                return null;
            }
            finally
            {
                Close();
            }

            return result;
        }

        public static bool ExecuteNonQuery(string query, List<OracleParameter> args = null)
        {
            var result = -1;
            try
            {
                using (var con = new OracleCommand(query, Connection))
                {
                    if (args != null)
                    {
                        foreach (var arg in args)
                        {
                           con.Parameters.Add(arg);
                        }
                    }

                    result = con.ExecuteNonQuery();
                }
            }
            catch (OracleException e)
            {
                Logger.Write(e.Message);
                return false;
            }
            finally
            {
                Close();
            }

            return result >= 0;
        }

        public static bool ExecuteNonQuery(string query, out string returnValue, List<OracleParameter> args = null)
        {
            var result = -1;

            OracleParameter returnParameter = null;
            returnValue = string.Empty;

            try
            {
                using (var con = new OracleCommand(query, Connection))
                {
                    if (args != null)
                    {
                        foreach (var arg in args)
                        {
                            if (arg.Direction == ParameterDirection.ReturnValue)
                            {
                                returnParameter = arg;
                            }
                            con.Parameters.Add(arg);
                        }
                    }

                    result = con.ExecuteNonQuery();

                    if (returnParameter != null)
                    {
                        returnValue = (returnParameter.Value.ToString());
                    }
                }
            }
            catch(OracleException e)
            {
                Logger.Write(e.Message);
                return false;
            }
            finally
            {
                Close();
            }

            return result >= 0;
        }

        public static object ExecuteScalar(string query, List<OracleParameter> args = null)
        {
            object result;

            try
            {
                using (var con = new OracleCommand(query, Connection))
                {
                    if (args != null)
                    {
                        foreach (var arg in args)
                        {
                            con.Parameters.Add(arg);
                        }
                    }

                    result = con.ExecuteScalar();
                }
            }
            catch (OracleException e)
            {
                Logger.Write(e.Message);
                return null;
            }
            finally
            {
                Close();
            }

            return result;
        }

        private static void Close()
        {
            _connection.Close();
            _connection.Dispose();
        }
    }
}
