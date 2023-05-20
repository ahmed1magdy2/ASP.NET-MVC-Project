using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Harbor.Models
{
    [PrimaryKey(nameof(UserId), nameof(ProductId))]
    public class Transaction
    {
        public Guid UserId { get; set; }
        public Guid ProductId { get; set; }
        [ForeignKey("UserId ")]
        public User User { get; set; }

        [ForeignKey("ProductId")]
        public Product Product { get; set; }
    }
}
