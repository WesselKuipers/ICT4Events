using System.Drawing;

namespace SharedModels.Models
{
    public class Location
    {
        public int ID { get; }
        public int Capacity { get; set; }
        public Event Event { get; }
        public Point Coordinates { get; set; }

        public Location(int id, int capacity, Event ev, Point coords)
        {
            ID = id;
            Capacity = capacity;
            Event = ev;
            Coordinates = coords;
        }

    }
}