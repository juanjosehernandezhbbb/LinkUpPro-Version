using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using LinkUpPro.Domain.Entities;

namespace LinkUpPro.Infrastructure.Persistances.EntitiesConfiguration;

public class ReaccionConfig : IEntityTypeConfiguration<Reaccion>
{
    public void Configure(EntityTypeBuilder<Reaccion> builder)
    {
        builder.HasKey(r => r.Id);

        builder.HasOne(r => r.Publicacion)
            .WithMany(p => p.Reacciones)
            .HasForeignKey(r => r.PublicacionId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(r => r.Usuario)
            .WithMany()
            .HasForeignKey(r => r.UsuarioId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(r => new { r.PublicacionId, r.UsuarioId })
            .IsUnique();
    }
}