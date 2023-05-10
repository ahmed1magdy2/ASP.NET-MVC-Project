using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Contracts;

namespace Harbor.Models
{
    public class Ships
    {
        [Key]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "must input ship name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "must input length")]
        public double Length { get; set; }
        [Required(ErrorMessage = "must input ship width")]
        public double Width { get; set; }
        [Required(ErrorMessage = "must input ship coming from")]
        public string Coming_from { get; set; }
        [Required(ErrorMessage = "must input Arrival Time")]
        public DateTime ArrivalDate{ get; set; }
        [Required(ErrorMessage = "must input Deprature Time")]
        public DateTime Departuredate { get; set; }
        [ForeignKey("PortId")]
        public Guid PortId { get; set; }

        public virtual Ports? Port { get; set; }
    }
}
