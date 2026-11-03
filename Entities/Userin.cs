using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class Userin
    {
        [Required]
        public string Password { get; set; }
        [EmailAddress]
        public string Email { get; set; }
    }
}
