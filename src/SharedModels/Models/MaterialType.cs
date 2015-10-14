namespace SharedModels.Models
{
    /// <summary>
    /// TODO: Inquire about MaterialType properties
    /// </summary>
    public class MaterialType
    {
        public int ID { get; }
        public string Name { get; set; }
        public Event Event { get; }
    }
}