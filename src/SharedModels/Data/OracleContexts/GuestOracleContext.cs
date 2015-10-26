using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.DataAccess.Client;
using SharedModels.Data.ContextInterfaces;
using SharedModels.Enums;
using SharedModels.Models;

namespace SharedModels.Data.OracleContexts
{
    public class GuestOracleContext : EntityOracleContext<Guest>, IGuestContext
    {
        public List<Guest> GetAll()
        {
            var query =
                "SELECT u.*, g.eventid, g.locationid, g.passid, g.paid, g.present, g.datestart, g.dateend FROM guest g INNER JOIN useraccount u ON g.userid = u.userid";

            var res = Database.ExecuteReader(query);
            return res.Select(GetEntityFromRecord).ToList();
        }

        public Guest GetById(object id)
        {
            var query =
                "SELECT u.*, g.eventid, g.locationid, g.passid, g.paid, g.present, g.datestart, g.dateend FROM guest g INNER JOIN useraccount u ON g.userid = u.userid WHERE u.userid = :userid";
            var parameters = new List<OracleParameter>
            {
                new OracleParameter("userid", (int) id)
            };

            return GetEntityFromRecord(Database.ExecuteReader(query, parameters).First());
        }

        public Guest Insert(Guest entity)
        {
            var query = "INSERT INTO guest (eventid, userid, locationid, passid, paid, datestart, dateend) VALUES (:eventid, :userid, :locationid, :passid, :paid, :datestart, :dateend)";
            var parameters = new List<OracleParameter>
            {
                new OracleParameter("eventid", entity.EventID),
                new OracleParameter("userid", entity.ID),
                new OracleParameter("locationid", entity.LocationID),
                new OracleParameter("passid", entity.PassID),
                new OracleParameter("paid", Convert.ToInt32(entity.Paid)),
                new OracleParameter("datestart", entity.StartDate) { OracleDbType = OracleDbType.Date},
                new OracleParameter("dateend", entity.EndDate) { OracleDbType = OracleDbType.Date}
            };

            string newID;
            if (!Database.ExecuteNonQuery(query, out newID, parameters)) return null;
            return GetById(Convert.ToInt32(newID));
        }

        public bool Update(Guest entity)
        {
            var query =
                "UPDATE guest SET locationid = :locationid, passid = :passid, paid = :paid, datestart = :datestart, dateend = :dateend WHERE eventid = :eventid AND userid = :userid";
            var parameters = new List<OracleParameter>
            {
                new OracleParameter("locationid", entity.LocationID),
                new OracleParameter("passid", entity.PassID),
                new OracleParameter("paid", Convert.ToInt32(entity.Paid)),
                new OracleParameter("datestart", entity.StartDate),
                new OracleParameter("dateend", entity.EndDate),
                new OracleParameter("eventid", entity.EventID),
                new OracleParameter("userid", entity.ID)
            };

            return Database.ExecuteNonQuery(query, parameters);
        }

        public bool Delete(Guest entity)
        {
            var query = "DELETE FROM guest WHERE userid = :userid AND eventid = :eventid";
            var parameters = new List<OracleParameter>
            {
                new OracleParameter("eventid", entity.EventID),
                new OracleParameter("userid", entity.ID)
            };

            return Database.ExecuteNonQuery(query, parameters);
        }

        public List<Guest> GetAllByEvent(Event ev)
        {
            var query =
                "SELECT u.*, g.eventid, g.locationid, g.passid, g.paid, g.present, g.datestart, g.dateend FROM guest g INNER JOIN useraccount u ON g.userid = u.userid WHERE eventid = :eventid";
            var parameters = new List<OracleParameter>
            {
                new OracleParameter("eventid", ev.ID)
            };

            var res = Database.ExecuteReader(query, parameters);
            return res.Select(GetEntityFromRecord).ToList();
        }

        public Guest GetGuestByEvent(Event ev, int userID)
        {
            var query =
                "SELECT u.*, g.eventid, g.locationid, g.passid, g.paid, g.present, g.datestart, g.dateend FROM guest g INNER JOIN useraccount u ON g.userid = u.userid WHERE eventid = :eventid AND g.userid = :userid";
            var parameters = new List<OracleParameter>
            {
                new OracleParameter("eventid", ev.ID),
                new OracleParameter("userid", userID)
            };

            return GetEntityFromRecord(Database.ExecuteReader(query, parameters).FirstOrDefault());
        }

        public int GetGuestCountByEvent(Event ev)
        {
            var query = "SELECT COUNT(*) FROM guest WHERE eventid = :eventid";
            var parameters = new List<OracleParameter>
            {
                new OracleParameter("eventid", ev.ID)
            };

            return Convert.ToInt32(Database.ExecuteScalar(query, parameters));
        }

        protected override Guest GetEntityFromRecord(List<string> record)
        {
            if (record == null) return null;

            // userid username password firstname surname country address city postal phonenumber regdate permissionlevel eventid locationid passid paid present datestart dateend
            // 0      1        2        3         4       5       6       7    8      9           10      11              12      13         14     15   16      17        18    
            return new Guest(Convert.ToInt32(record[0]), record[1], record[2], record[3], record[14],
                Convert.ToBoolean(Convert.ToInt32(record[15])), Convert.ToInt32(record[12]), Convert.ToBoolean(Convert.ToInt32(record[16])),
                DateTime.Parse(record[17]), DateTime.Parse(record[18]), Convert.ToInt32(record[13]),
                DateTime.Parse(record[10]), (PermissionType) Convert.ToInt32(record[11]), record[4],
                (Country) Enum.Parse(typeof (Country), record[5]), record[7], record[8], record[6], record[9]);
        }
    }
}
