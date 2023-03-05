namespace Modsen.DL.Entities
{
    public class Event
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Speaker { get; set; }
        public string Organizer { get; set; }
        public string Place { get; set; }
        public DateTime Time { get; set; }
    }
}
