using Microsoft.AspNetCore.Identity;

namespace Labo8.Models
{
    public class User : IdentityUser
    {
        public virtual List<Gallerie> Galleries { get; set; }
    }
}
