using System.ComponentModel.DataAnnotations;

namespace Labo8.Models
{
    public class RegisterDTO
    {
        public int Id { get; set; }

        [Required]
        public string Username { get; set; } = null!;

        [Required]
       
        public string Password { get; set; } = null!;

        [Required]
        public string PasswordConfirm { get; set; } = null!;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;
    }
}
