using System.ComponentModel.DataAnnotations;

namespace Labo8.Models
{
    public class Gallerie
    {
        public int Id { get; set; }
        [Required]
        public bool Publique { get; set; }
        public string? Image { get; set; }

        public virtual List<User> Users { get; set; } = null!;
    }
}
