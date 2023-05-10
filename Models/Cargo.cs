using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Harbor.Models
{
    public class Cargo
    {
        [Key]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "must input cargo type")]
        public string Type { get; set; }
        [Required(ErrorMessage = "must input quantity")]
        public double Quantity { get; set; }
        [Required(ErrorMessage = "must input destination")]
        public string Destination { get; set; }
        [ForeignKey("ShipId")]
        public Guid ShipId { get; set; }

        public virtual Ships? Ship { get; set; }    
    }
}
