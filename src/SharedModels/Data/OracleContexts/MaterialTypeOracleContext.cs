using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.DataAccess.Client;
using SharedModels.Data.ContextInterfaces;
using SharedModels.Enums;
using SharedModels.Models;

namespace SharedModels.Data.OracleContexts
{
    public class MaterialTypeOracleContext : EntityOracleContext<MaterialType>, IMaterialTypeContext
    {

        /*public List<Media> GetAll()
        {
            var query = "SELECT * FROM media ORDER BY mediaid";
            var res = Database.ExecuteReader(query);

            return res.Select(GetEntityFromRecord).ToList();
        }

        public Media GetById(object id)
        {
            var query = "SELECT * FROM media WHERE mediaid = :mediaid ORDER BY mediaid";
            var parameters = new List<OracleParameter>
            {
                new OracleParameter("mediaid", (int) id)
            };

            return GetEntityFromRecord(Database.ExecuteReader(query, parameters).First());
        }

        public Media Insert(Media entity)
        {
            var query =
                "INSERT INTO media (mediaid, userid, eventid, mediatypeid, name, fileextension, filepath) VALUES (seq_media.nextval, :userid, :eventid, :mediatypeid, :name, :fileextension, :filepath) RETURNING mediaid INTO :lastID";
            var parameters = new List<OracleParameter>
            {
                new OracleParameter("userid", entity.UserID),
                new OracleParameter("eventid", entity.EventID),
                new OracleParameter("mediatypeid", Convert.ToInt32(entity.Type)),
                new OracleParameter("name", entity.Name),
                new OracleParameter("fileextension", entity.FileExtension),
                new OracleParameter("filepath", entity.Path),
                new OracleParameter("lastID", OracleDbType.Decimal) {Direction = ParameterDirection.ReturnValue}
            };

            string newID;
            if (!Database.ExecuteNonQuery(query, out newID, parameters)) return null;
            return GetById(Convert.ToInt32(newID));
        }

        public bool Update(Media entity)
        {
            var query = "UPDATE media SET name = :name, fileextension = :fileextension, filepath = :filepath WHERE mediaid = :mediaid";
            var parameters = new List<OracleParameter>
            {
                new OracleParameter("name", entity.Name),
                new OracleParameter("fileextension", entity.FileExtension),
                new OracleParameter("filepath", entity.Path),
                new OracleParameter("mediaid", entity.ID)
            };

            return Database.ExecuteNonQuery(query, parameters);
        }

        public bool Delete(Media entity)
        {
            var query = "DELETE FROM media WHERE mediaid = :mediaid";
            var parameters = new List<OracleParameter> { new OracleParameter("mediaid", entity.ID) };

            return Database.ExecuteNonQuery(query, parameters);
        }

        public List<Media> GetAllByGuest(Guest guest)
        {
            var query = "SELECT * FROM media WHERE eventid = :eventid AND userid = :userid ORDER BY mediaid";
            var parameters = new List<OracleParameter>
            {
                new OracleParameter("eventid", guest.EventID),
                new OracleParameter("eventid", guest.ID)
            };

            var res = Database.ExecuteReader(query, parameters);

            return res.Select(GetEntityFromRecord).ToList();
        }

        protected override Media GetEntityFromRecord(List<string> record)
        {
            return new Media(Convert.ToInt32(record[0]), Convert.ToInt32(record[1]), Convert.ToInt32(record[2]),
                (MediaType) Convert.ToInt32(record[3]), record[4], record[5], record[6]);
        }*/
        public List<MaterialType> GetAll()
        {
            var query = "SELECT * FROM materialtype ORDER BY materialtypeid";
            var res = Database.ExecuteReader(query);

            return res.Select(GetEntityFromRecord).ToList();
        }

        public MaterialType GetById(object id)
        {
            var query = "SELECT * FROM materialtype WHERE materialtypeid = :materialtypeid ORDER BY materialtypeid";
            var parameters = new List<OracleParameter>
            {
                new OracleParameter("materialtypeid", (int) id)
            };

            return GetEntityFromRecord(Database.ExecuteReader(query, parameters).First());
        }

        public MaterialType Insert(MaterialType entity)
        {
            var query =
                "INSERT INTO materialtype (materialtypeid, name) VALUES (seq_materialtype.nextval, :name) RETURNING mediaid INTO :lastID";
            var parameters = new List<OracleParameter>
            {
                new OracleParameter("name", entity.Name),
                new OracleParameter("lastID", OracleDbType.Decimal) {Direction = ParameterDirection.ReturnValue}
            };

            string newID;
            if (!Database.ExecuteNonQuery(query, out newID, parameters)) return null;
            return GetById(Convert.ToInt32(newID));
        }

        public bool Update(MaterialType entity)
        {
            var query = "UPDATE materialtype SET name = :name WHERE materialtypeid = :materialtypeid";
            var parameters = new List<OracleParameter>
            {
                new OracleParameter("name", entity.Name),
                new OracleParameter("materialtypeid", entity.ID)
            };

            return Database.ExecuteNonQuery(query, parameters);
        }

        public bool Delete(MaterialType entity)
        {
            var query = "DELETE FROM materialtype WHERE materialtypeid = :materialtypeid";
            var parameters = new List<OracleParameter> { new OracleParameter("materialtypeid", entity.ID) };

            return Database.ExecuteNonQuery(query, parameters);
        }

        protected override MaterialType GetEntityFromRecord(List<string> record)
        {
            return new MaterialType(Convert.ToInt32(record[0]), record[1]);
        }
    }
}
