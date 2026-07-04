using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using LinkUp.Core.Domain.Entities; // Asegúrate de importar esto donde vive ApplicationUser

namespace LinkUp.Infrastructure.Persistence.Context
{
    // Cambiamos <AppUser> por <ApplicationUser>
    public class IdentityContext : IdentityDbContext<ApplicationUser>
    {
        public IdentityContext(DbContextOptions<IdentityContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.HasDefaultSchema("Identity");

            // Asegúrate de que estas tablas coincidan con el tipo ApplicationUser
            builder.Entity<ApplicationUser>().ToTable("users");
            builder.Entity<IdentityRole>().ToTable("roles");
            builder.Entity<IdentityUserRole<string>>().ToTable("user_roles");
            builder.Entity<IdentityUserLogin<string>>().ToTable("user_logins");
        }
    }
}