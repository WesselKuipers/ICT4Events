using System;

namespace SharedModels.Models
{
    public class Event
    {
        public int ID { get; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string MapPath { get; set; }
        public int MaxCapacity { get; set; }

        public Event(int id, string name, DateTime start, DateTime end, string mapPath = "", int maxCap = 100)
        {
            ID = id;
            Name = name;
            StartDate = start;
            EndDate = end;
            MapPath = mapPath;
            MaxCapacity = maxCap;
        }
    }
}