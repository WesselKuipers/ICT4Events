using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.DataAccess.Client;
using SharedModels.Data.ContextInterfaces;
using SharedModels.Enums;
using SharedModels.Models;

namespace SharedModels.Data.OracleContexts
{
    class UserOracleContext : IUserContext
    {
        // TODO: Test all of these queries.

        public List<User> GetAll()
        {
            var users = new List<User>();
            var query = "SELECT * FROM useraccount";
            var res = Database.ExecuteReader(query);

            while (res.Read())
            {
                users.Add(GetUserFromRecord(res));
            }

            return users;
        }

        public User GetById(int id)
        {
            var query = "SELECT * FROM useraccount WHERE userid = :userid";
            var parameters = new List<OracleParameter>
            {
                new OracleParameter("userid", id)
            };

            return GetUserFromRecord(Database.ExecuteReader(query, parameters));
        }

        public User Insert(User user)
        {
            var query =
                "INSERT INTO useraccount (userid, username, password, firstname, surname, country, address, city, postal, phonenumber, permissionlevel) VALUES (seq_user.nextval, :username, :firstname, :surname, :country, :address, :city, :postal, :phonenumber, :permissionlevel)";
            var parameters = new List<OracleParameter>
            {
                new OracleParameter("password", user.Password),
                new OracleParameter("firstname", user.Name),
                new OracleParameter("surname", user.Surname),
                new OracleParameter("country", user.Country),
                new OracleParameter("address", user.Address),
                new OracleParameter("city", user.City),
                new OracleParameter("postal", user.Postal),
                new OracleParameter("phonenumber", user.Telephone),
                new OracleParameter("permissionlevel", (int)user.Permission)
            };

            return GetUserFromRecord(Database.ExecuteReader(query, parameters));
        }

        public bool Update(User user)
        {
            const string query = "UPDATE useraccount SET firstname = :firstname, surname = :surname, country = :country, address = :address, city = :city, postal = :postal, phonenumber = :phonenumber, permissionlevel = :permissionlevel WHERE userid = :userid";
            var parameters = new List<OracleParameter>
            {
                new OracleParameter("userid", user.ID),
                new OracleParameter("firstname", user.Name),
                new OracleParameter("surname", user.Surname),
                new OracleParameter("country", user.Country),
                new OracleParameter("address", user.Address),
                new OracleParameter("city", user.City),
                new OracleParameter("postal", user.Postal),
                new OracleParameter("phonenumber", user.Telephone),
                new OracleParameter("permissionlevel", (int)user.Permission)
            };

            return Database.ExecuteNonQuery(query, parameters);
        }

        public bool Delete(User user)
        {
            var query = "DELETE FROM useraccount WHERE userid = :userid";
            var parameters = new List<OracleParameter> {new OracleParameter("userid", user.ID)};

            return Database.ExecuteNonQuery(query, parameters);
        }

        private User GetUserFromRecord(OracleDataReader record)
        {
            var values = new string[record.FieldCount];

            return new User(Convert.ToInt32(values[0]), values[1], values[2], values[3], values[5], values[4],
                values[7], values[8], values[6], values[9],
                DateTime.ParseExact(values[10], "MM-dd-yyyy", CultureInfo.InvariantCulture),
                (PermissionType)Convert.ToInt32(values[11]));
        }
    }
}
