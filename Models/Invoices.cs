using System.ComponentModel.DataAnnotations;

namespace asp.net_project.Models
{
    public class Invoices
    {
        [Key]
        public Guid Id { get; set; }
        public Guid PortId { get; set; }
        public Guid TransId { get; set; }
        public virtual Ports Ports { get; set; }
        public virtual ICollection<Transactions> Transactions { get; set; }
    }
}
