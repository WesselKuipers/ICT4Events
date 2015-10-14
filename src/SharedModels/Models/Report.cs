using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedModels.Models
{
    public class Report
    {
        public Guest Guest { get; set; }
        public Post Post { get; set; }
        public string Reason { get; set; }
        public DateTime Date { get; set; }
        public bool Status { get; set; } // Is a status type enum actually necessary?

        public Report(Guest guest, Post post, string reason, DateTime date, bool status)
        {
            Guest = guest;
            Post = post;
            Reason = reason;
            Date = date;
            Status = status;
        }
    }
}
