using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Harbor.Models
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }
        [Required (ErrorMessage ="must input username")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "must input national id")]
        public string NationalId { get; set; }
        [Required (ErrorMessage = "must input Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "must input password")]
        public string Password { get; set; }


        public ICollection<Cart>? Carts { get; set; }
        public ICollection<Transaction>? Transactions { get; set; }
    }
}
