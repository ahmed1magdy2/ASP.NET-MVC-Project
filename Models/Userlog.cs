using System.ComponentModel.DataAnnotations;

namespace Harbor.Models
{
    public class Userlog
    {
        [Required(ErrorMessage = "must input username")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "must input password")]
        public string Password { get; set; }
    }
}
