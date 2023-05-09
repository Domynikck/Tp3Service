using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Labo8.Models
{
    public class Gallerie
    {
        public int Id { get; set; }
        [Required]
        public bool Publique { get; set; }
        public string GallerieName { get; set; }

        [ForeignKey("CoverID")]
        public int? CoverID { get; set; }
        [JsonIgnore]
        public virtual List<User>? Users { get; set; } = null!;

        [JsonIgnore]
        public virtual List<Photo>? Photos { get; set; }
    }
}
