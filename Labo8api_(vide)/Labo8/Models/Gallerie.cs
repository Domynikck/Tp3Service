using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Labo8.Models
{
    public class Gallerie
    {
        public int Id { get; set; }
        [Required]
        public bool Publique { get; set; }
        public string? Image { get; set; }
        public string GallerieName { get; set; }

        [JsonIgnore]
        public virtual List<User>? Users { get; set; } = null!;
    }
}
