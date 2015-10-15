using System;
using SharedModels.Enums;

namespace SharedModels.Models
{
    public class Guest : User
    {
        public int PassNumber { get; set; }
        public bool Paid { get; set; }
        public Event Event { get; }
        public bool Present { get; set; }
        public DateTime StartDate { get; }
        public DateTime EndDate { get; }
        public Location Location { get; set; }

        public Guest(int id, string username, string password, string name, int passNumber, bool paid, Event ev,
            bool present, DateTime startDate, DateTime endDate, Location location, DateTime regDate = new DateTime(),
            PermissionType permission = PermissionType.User, string surname = "", string country = "", string city = "",
            string postal = "", string address = "", string telephone = "")
            : base(id, username, password, name, surname, country, city, postal, address, telephone, regDate, permission)
        {
            PassNumber = passNumber;
            Paid = paid;
            Event = ev;
            Present = present;
            StartDate = startDate;
            EndDate = endDate;
            Location = location;
        }
    }
}
