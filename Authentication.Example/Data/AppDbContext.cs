using Authentication.Example.Constants;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Threading.Tasks;

namespace Authentication.Example.Data
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            #region Create Roles
            var moderatorRoleId = Guid.NewGuid().ToString();
            var adminRoleId = Guid.NewGuid().ToString();

            builder.Entity<IdentityRole>().HasData(
                new IdentityRole { Id = moderatorRoleId, Name = RoleNames.Moderator, NormalizedName = RoleNames.Moderator.ToUpper() },
                new IdentityRole { Id = adminRoleId, Name = RoleNames.Administrator, NormalizedName = RoleNames.Administrator.ToUpper() }
            );

            #endregion
            #region Create Users
            var hasher = new PasswordHasher<AppUser>();
            var moderatorUser = new AppUser
            {
                UserName = "Moderator",
                NormalizedUserName = "MODERATOR",
                Email = "moderator@example.com",
                NormalizedEmail = "MODERATOR@EXAMPLE.COM",
                EmailConfirmed = true
            };
            moderatorUser.PasswordHash = hasher.HashPassword(moderatorUser, "Test@123");

            var adminUser = new AppUser
            {
                UserName = "Administrator",
                NormalizedUserName = "ADMINISTRATOR",
                Email = "administrator@example.com",
                NormalizedEmail = "ADMINISTRATOR@EXAMPLE.COM",
                EmailConfirmed = true
            };
            adminUser.PasswordHash = hasher.HashPassword(adminUser, "Test@123");

            builder.Entity<AppUser>().HasData(moderatorUser, adminUser);
            #endregion

            #region Create User Roles
            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string> { UserId = moderatorUser.Id, RoleId = moderatorRoleId },
                new IdentityUserRole<string> { UserId = adminUser.Id, RoleId = moderatorRoleId },
                new IdentityUserRole<string> { UserId = adminUser.Id, RoleId = adminRoleId }
            );
            #endregion
        }













































    }
}
