using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Harbor.Models
{

    public class Berths
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Capacity { get; set; }
        [ForeignKey("PortId")]
        public Guid PortId { get; set; }

        public virtual Ports? Port { get; set; }
        public virtual ICollection<Ships> Ships { get; set; }
        public virtual ICollection<Cargo> Cargo { get; set; }
    }
}
