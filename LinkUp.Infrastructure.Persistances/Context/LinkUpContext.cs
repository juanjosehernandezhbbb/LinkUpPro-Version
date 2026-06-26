using LinkUpPro.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace LinkUp.Infrastructure.Persistence.Context
{
    public class LinkUpContext : IdentityDbContext<ApplicationUser>
    {
        public LinkUpContext(DbContextOptions<LinkUpContext> options) : base(options)
        {
        }

        public DbSet<Publicacion> Publicaciones { get; set; }
        public DbSet<Comentario> Comentarios { get; set; }
        public DbSet<Reaccion> Reacciones { get; set; }
        public DbSet<Notificacion> Notificaciones { get; set; }

        public DbSet<Amistad> Amistades { get; set; }
        public DbSet<SolicitudAmistad> SolicitudesAmistad { get; set; }

        public DbSet<PartidaBattleship> Partidas { get; set; }
        public DbSet<Barco> Barcos { get; set; }
        public DbSet<CeldaBarco> CeldasBarco { get; set; }
        public DbSet<Ataque> Ataques { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());


        }
    }
}

