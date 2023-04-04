using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Labo8.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Labo8.Data
{
    public class Labo8Context : IdentityDbContext<User>
    {
        public Labo8Context (DbContextOptions<Labo8Context> options)
            : base(options)
        {
        }

        public DbSet<Labo8.Models.Animal> Animal { get; set; } = default!;
        public DbSet<Labo8.Models.Gallerie> Gallerie { get; set; }
    }
}
