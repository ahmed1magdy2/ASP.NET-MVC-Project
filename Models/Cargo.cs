namespace asp.net_project.Models
{
    public class Cargo
    {
        public Guid Id { get; set; }
        public string Type { get; set; }
        public long Quantity { get; set; }
        public string Destination { get; set; }
    }
}
