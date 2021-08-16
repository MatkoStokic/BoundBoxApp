using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BoundBoxApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var roles = new IdentityRole[]
            {
                new IdentityRole
                {
                    Id = "8e445865-a24d-4543-a6c6-9443d048cdb9",
                    Name = "Admin",
                    NormalizedName = "Admin".ToUpper()
                },
                new IdentityRole
                {
                    Id = "8e445865-a24d-4543-a6c6-9443d048cdb8",
                    Name = "Annotator",
                    NormalizedName = "Annotator".ToUpper()
                },
                new IdentityRole
                {
                    Id = "8e445865-a24d-4543-a6c6-9443d048cdb7",
                    Name = "User",
                    NormalizedName = "User".ToUpper()
                }
            };

            foreach(IdentityRole role in roles)
            {
                modelBuilder.Entity<IdentityRole>().HasData(role);
            }

            var hasher = new PasswordHasher<IdentityUser>();

            var users = new IdentityUser[]
            {
                new IdentityUser
                {
                    Id = "8e445865-a24d-4543-a6c6-9443d048cdb9",
                    Email = "admin@admin.com",
                    NormalizedEmail = "ADMIN@ADMIN.COM",
                    UserName = "Admin",
                    NormalizedUserName = "Admin",
                    PhoneNumber = "",
                    EmailConfirmed = true,
                    PhoneNumberConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "pass")
                },
                new IdentityUser
                {
                    Id = "8e445865-a24d-4543-a6c6-9443d048cdb8",
                    Email = "annotator@annotator.com",
                    NormalizedEmail = "ANNOTATOR@ANNOTATOR.COM",
                    UserName = "Annotator",
                    NormalizedUserName = "Annotator",
                    PhoneNumber = "",
                    EmailConfirmed = true,
                    PhoneNumberConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "pass")
                },
                new IdentityUser
                {
                    Id = "8e445865-a24d-4543-a6c6-9443d048cdb7",
                    Email = "user@user.com",
                    NormalizedEmail = "USER@USER.COM",
                    UserName = "User",
                    NormalizedUserName = "User",
                    PhoneNumber = "",
                    EmailConfirmed = true,
                    PhoneNumberConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "pass")
                }
            };

            foreach (IdentityUser user in users)
            {
                modelBuilder.Entity<IdentityUser>().HasData(user);
            }

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "8e445865-a24d-4543-a6c6-9443d048cdb9",
                    UserId = "8e445865-a24d-4543-a6c6-9443d048cdb9"
                }
            );
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "8e445865-a24d-4543-a6c6-9443d048cdb8",
                    UserId = "8e445865-a24d-4543-a6c6-9443d048cdb8"
                }
            );
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "8e445865-a24d-4543-a6c6-9443d048cdb7",
                    UserId = "8e445865-a24d-4543-a6c6-9443d048cdb7"
                }
            );
        }
    }
}
