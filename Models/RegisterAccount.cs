using System.ComponentModel.DataAnnotations;

namespace asp.net_project.Models
{
    public class RegisterAccount
    {
        [Key]
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfPassword { get; set; }
    }
}
