using System.ComponentModel.DataAnnotations;


namespace Labo8.Models
{
    public class LoginDTO
    {
        [Required]
        public string Username { get; set; } = null!;

        [Required]
        public String Password { get; set; } = null!;
    }
}
