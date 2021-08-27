using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using BoundBoxApp.Model;

namespace BoundBoxApp.DAL
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Project> Projects { get; set; }
        public DbSet<Bounds> Bounds { get; set; }
        public DbSet<Marker> Markers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<IdentityUser>().ToTable("User");
            modelBuilder.Entity<IdentityUserRole<string>>().ToTable("UserRole");
            modelBuilder.Entity<IdentityUserLogin<string>>().ToTable("UserLogin");
            modelBuilder.Entity<IdentityUserClaim<string>>().ToTable("UserClaim");
            modelBuilder.Entity<IdentityUserToken<string>>().ToTable("UserToken");
            modelBuilder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaim");
            modelBuilder.Entity<IdentityRole>().ToTable("Role");

            AddRoles(modelBuilder);
            AddRoleClaims(modelBuilder);
            AddUsers(modelBuilder);
            AddUserRoles(modelBuilder);

            
        }

        private void AddRoles(ModelBuilder modelBuilder)
        {
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

            foreach (IdentityRole role in roles)
            {
                modelBuilder.Entity<IdentityRole>().HasData(role);
            }
        }

        private void AddRoleClaims(ModelBuilder modelBuilder)
        {
            var roleClaims = new IdentityRoleClaim<string>[]
            {
                new IdentityRoleClaim<string>
                {
                    Id = 1,
                    RoleId = "8e445865-a24d-4543-a6c6-9443d048cdb9",
                    ClaimType = "Role",
                    ClaimValue = "Admin"
                },
                new IdentityRoleClaim<string>
                {
                    Id = 2,
                    RoleId = "8e445865-a24d-4543-a6c6-9443d048cdb8",
                    ClaimType = "Role",
                    ClaimValue = "Annotator"
                },
                new IdentityRoleClaim<string>
                {
                    Id = 3,
                    RoleId = "8e445865-a24d-4543-a6c6-9443d048cdb7",
                    ClaimType = "Role",
                    ClaimValue = "User"
                }
            };

            foreach (IdentityRoleClaim<string> roleClaim in roleClaims)
            {
                modelBuilder.Entity<IdentityRoleClaim<string>>().HasData(roleClaim);
            }
        }

        private void AddUsers(ModelBuilder modelBuilder)
        {
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
        }

        private void AddUserRoles(ModelBuilder modelBuilder)
        {
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
