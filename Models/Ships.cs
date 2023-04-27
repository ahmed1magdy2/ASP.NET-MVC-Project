using System.ComponentModel.DataAnnotations;

namespace asp.net_project.Models
{
    public class Ships
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public double Length { get; set; }
        public double Width { get; set; }
        public DateTime ArrivalDate{ get; set; }
        public DateTime Departuredate { get; set; }
    }
}
