using SharedModels.Enums;

namespace SharedModels.Models
{
    public class Media
    {
        public int ID { get; }
        public string Path { get; set; }
        public MediaType Type { get; set; }

        public Media(int id, string path, MediaType type)
        {
            ID = id;
            Path = path;
            Type = type;
        }
    }
}