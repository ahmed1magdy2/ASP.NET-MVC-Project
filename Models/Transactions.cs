using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Harbor.Models
{
    public class Transactions
    {
        [Key]
        public Guid Id { get; set; }
        [ForeignKey("UserId")]
        public Guid UserId { get; set; }
        [ForeignKey("BerthId")]
        public Guid BerthId { get; set; }
        [ForeignKey("PortId")]
        public Guid PortId { get; set; }
        public string Type { get; set; }
        public DateTime Date { get; set; }
        public double Amount { get; set; }

        public virtual User? User { get; set; }
        public virtual Ports? Ports { get; set; }
        public virtual Berths? Berth { get; set; }
        public virtual ICollection <Ships>? Ships { get; set; }
        public virtual ICollection <Cargo>? Cargo { get; set; }
    }
}
