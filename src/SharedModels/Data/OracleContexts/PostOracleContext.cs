using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.DataAccess.Client;
using SharedModels.Data.ContextInterfaces;
using SharedModels.Models;

namespace SharedModels.Data.OracleContexts
{
    public class PostOracleContext : EntityOracleContext<Post>, IPostContext
    {
        public List<Post> GetAll()
        {
            var query = "SELECT * FROM post ORDER BY postid";
            var res = Database.ExecuteReader(query);

            return res.Select(GetEntityFromRecord).ToList();
        }

        public Post GetById(object id)
        {
            var query = "SELECT * FROM post WHERE postid = :postid ORDER BY postid";
            var parameters = new List<OracleParameter>
            {
                new OracleParameter("postid", Convert.ToInt32(id))
            };

            return GetEntityFromRecord(Database.ExecuteReader(query, parameters).First());
        }

        public Post Insert(Post entity)
        {
            var query =
                "INSERT INTO post (postid, userid, eventid, mediaid, postdate, content) VALUES (seq_post.nextval, :userid, :eventid, :mediaid, :postdate, :content) RETURNING postid INTO :lastID";
            var parameters = new List<OracleParameter>
            {
                new OracleParameter("userid", entity.GuestID),
                new OracleParameter("eventid", entity.EventID),
                new OracleParameter("mediaid", entity.MediaID),
                new OracleParameter("postdate", entity.Date),
                new OracleParameter("content", entity.Content),
                new OracleParameter("lastID", OracleDbType.Decimal) {Direction = ParameterDirection.ReturnValue}
            };

            string newID;
            if (!Database.ExecuteNonQuery(query, out newID, parameters)) return null;
            return GetById(Convert.ToInt32(newID));
        }

        public bool Update(Post entity)
        {
            var query = "UPDATE post SET mediaid = :mediaid, postdate = :postdate, visible = :visible, content = :content WHERE postid = :postid";
            var parameters = new List<OracleParameter>
            {
                new OracleParameter("mediaid", entity.MediaID),
                new OracleParameter("postdate", entity.Date) {OracleDbType = OracleDbType.Date},
                new OracleParameter("visible", Convert.ToInt32(entity.Visible)),
                new OracleParameter("content", entity.Content),
                new OracleParameter("postid", entity.ID)
            };

            return Database.ExecuteNonQuery(query, parameters);
        }

        public bool Delete(Post entity)
        {
            var query = "DELETE FROM post WHERE postid = :postid";
            var parameters = new List<OracleParameter>
            {
                new OracleParameter("postid", entity.ID)
            };

            return Database.ExecuteNonQuery(query, parameters);
        }

        public List<Post> GetAllByEvent(Event ev)
        {
            var query = "SELECT * FROM post WHERE eventid = :eventid ORDER BY postid";
            var parameters = new List<OracleParameter>
            {
                new OracleParameter("eventid", ev.ID)
            };

            var res = Database.ExecuteReader(query, parameters);

            return res.Select(GetEntityFromRecord).ToList();
        }

        public List<Reply> GetRepliesByPost(Post post)
        {
            var query = "SELECT * FROM post WHERE mainpostid IS NOT NULL ORDER BY postid";
            var res = Database.ExecuteReader(query);

            return res.Select(GetReplyEntityFromRecord).ToList();
        }

        protected override Post GetEntityFromRecord(List<string> record)
        {
            //postid userid eventid mediaid mainpostid postdate visible content
            //0      1      2       3       4          5        6       7

            if (!string.IsNullOrEmpty(record[4]))
            {
                return GetReplyEntityFromRecord(record);
            }

            for (int i = 0; i < record.Count; i++)
            {
                if (string.IsNullOrEmpty((record[i])))
                {
                    record[i] = "0";
                }
            }

            return new Post(Convert.ToInt32(record[0]), Convert.ToInt32(record[1]), Convert.ToInt32(record[2]),
                Convert.ToInt32(record[3]), DateTime.Parse(record[5]), Convert.ToBoolean(Convert.ToInt32(record[6])), record[7]);
        }

        private Reply GetReplyEntityFromRecord(List<string> record)
        {
            if (record == null) return null;
            for (int i = 0; i < record.Count; i++)
            {
                if (string.IsNullOrEmpty((record[i])))
                {
                    record[i] = "0";
                }
            }
            return new Reply(Convert.ToInt32(record[0]), Convert.ToInt32(record[1]), Convert.ToInt32(record[2]),
                    Convert.ToInt32(record[3]), Convert.ToInt32(record[4]), DateTime.Parse(record[5]),
                    Convert.ToBoolean(Convert.ToInt32(record[6])), record[7]);
        }
    }
}
