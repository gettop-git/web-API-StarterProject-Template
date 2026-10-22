using System.ComponentModel.DataAnnotations;

namespace web_api
{
    public class Userin
    {
        [Required]
        public string Password { get; set; }
        [EmailAddress]
        public string Email { get; set; }
    }
}
