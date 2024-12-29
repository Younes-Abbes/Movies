using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace WebApplication1.Data
{
    public class AuthDbContext : IdentityDbContext
    {
        public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed roles
            var adminRoleId = "44b208b1-2b12-4207-b6b0-6f85c3c1c942";
            var userRoleId = "fc84f222-d5ac-41cc-bed6-a76ab674b28c";
            var superAdminRoleId = "3b97e621-b969-4dff-90e8-141cb01a2996";

            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole { Id = adminRoleId, Name = "Admin", NormalizedName = "ADMIN", ConcurrencyStamp = adminRoleId },
                new IdentityRole { Id = userRoleId, Name = "User", NormalizedName = "USER", ConcurrencyStamp = userRoleId },
                new IdentityRole { Id = superAdminRoleId, Name = "SuperAdmin", NormalizedName = "SUPERADMIN", ConcurrencyStamp = superAdminRoleId }
            );

            // Seed super admin user
            var superAdminUserId = "3d80677f-bd4a-43b2-86f0-97d7c32b256c";
            var superAdminUser = new IdentityUser
            {
                Id = superAdminUserId,
                UserName = "test@gmail.com",
                NormalizedUserName = "TEST@GMAIL.COM",
                Email = "test@gmail.com",
                NormalizedEmail = "TEST@GMAIL.COM",
                EmailConfirmed = true
            };

            // Password hashing
            superAdminUser.PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(superAdminUser, "123456789");

            modelBuilder.Entity<IdentityUser>().HasData(superAdminUser);

            // Assign roles to the super admin user
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string> { RoleId = adminRoleId, UserId = superAdminUserId },
                new IdentityUserRole<string> { RoleId = userRoleId, UserId = superAdminUserId },
                new IdentityUserRole<string> { RoleId = superAdminRoleId, UserId = superAdminUserId }
            );
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Optionally suppress pending model changes warning (temporary measure)
            optionsBuilder.ConfigureWarnings(warnings => warnings.Ignore(RelationalEventId.PendingModelChangesWarning));
        }
    }
}
