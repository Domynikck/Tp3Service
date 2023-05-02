using System.Text.Json.Serialization;

namespace Labo8.Models
{
    public class Photo
    {
        public int Id { get; set; }
        public string? FileName { get; set; }
        public string? MimeType { get; set; }

        [JsonIgnore]
        public virtual Gallerie? Gallerie { get; set; } = null!;
    }
}
