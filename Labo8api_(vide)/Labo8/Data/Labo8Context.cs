using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Labo8.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace Labo8.Data
{
    public class Labo8Context : IdentityDbContext<User>
    {
        public Labo8Context (DbContextOptions<Labo8Context> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);


            PasswordHasher<User> passwordHasher = new PasswordHasher<User>();
            User u1 = new User
            {
                Id = "11111111-1111-1111-1111-111111111111",
                UserName = "Hugo",
                Email = "samuelbienvenue@gmail.com",
                NormalizedUserName = "HUGO",
                NormalizedEmail = "SAMUELBIENVENUE@GMAIL.COM"
            };
            u1.PasswordHash = passwordHasher.HashPassword(u1, "Salut1!");
            User u2 = new User
            {
                Id = "11111111-1111-1111-1111-111111111112",
                UserName = "Eglantin",
                Email = "samuelbienvenue@gmail.com",
                NormalizedEmail = "SAMUELBIENVENUE@GMAIL.COM",
                NormalizedUserName = "EGLANTIN"
            };
            u2.PasswordHash = passwordHasher.HashPassword(u2, "Salut1!");

            builder.Entity<User>().HasData(u1, u2);

            builder.Entity<Gallerie>().HasData(
                new {Id = 1, Publique = true, GallerieName = "Incroyable" },
                new { Id = 2, Publique = false, GallerieName = "IncroyableMais2EtPrive" },
                new { Id = 3, Publique = true, GallerieName = "Champagne" },
                new { Id = 4, Publique = false, GallerieName = "EglantinEtEglantine" }
                );
            builder.Entity<Gallerie>()
                .HasMany(u => u.Users)
                .WithMany(g => g.Galleries)
                .UsingEntity(e =>
                {
                    e.HasData(new { UsersId = u1.Id, GalleriesId = 1 });
                    e.HasData(new { UsersId = u1.Id, GalleriesId = 2 });
                    e.HasData(new { UsersId = u2.Id, GalleriesId = 3 });
                    e.HasData(new { UsersId = u2.Id, GalleriesId = 4 });
                });
        }


        public DbSet<Labo8.Models.Animal> Animal { get; set; } = default!;
        public DbSet<Labo8.Models.Gallerie> Gallerie { get; set; }
        public DbSet<Labo8.Models.Photo> Photo { get; set; }
    }
}
