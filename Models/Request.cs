using System.ComponentModel.DataAnnotations;

namespace Harbor.Models
{
    public class Request
    {
        [Key]
        public Guid Id { get; set; }
        public string Type { get; set; }
        public string ShipName { get; set; }
        [Required(ErrorMessage = "must input length")]
        public double Length { get; set; }
        [Required(ErrorMessage = "must input ship width")]
        public double Width { get; set; }
        [Required(ErrorMessage = "must input ship coming from")]
        public string Coming_from { get; set; }
        [Required(ErrorMessage = "must input Arrival Time")]
        public DateTime ArrivalDate { get; set; }
        [Required(ErrorMessage = "must input Deprature Time")]
        public DateTime Departuredate { get; set; }
        public string portName { get; set; }
        public string CargoType { get; set; }
        [Required(ErrorMessage = "must input quantity")]
        public double Quantity { get; set; }
        [Required(ErrorMessage = "must input destination")]
        public string Destination { get; set; }
    }
}
