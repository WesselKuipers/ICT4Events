using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedModels.Models
{
    public class Material
    {
        public int ID { get; }
        public string Name { get; set; }
        public Event Event { get; }
        public MaterialType Type { get; set; }
        public Guest Guest { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public Material(int id, string name, Event ev, MaterialType type)
        {
            ID = id;
            Name = name;
            Event = ev;
            Type = type;
        }

        public Material(int id, string name, Event ev, MaterialType type, Guest guest, DateTime start, DateTime end)
            : this(id, name, ev, type)
        {
            Guest = guest;
            StartDate = start;
            EndDate = end;
        }
    }
}
