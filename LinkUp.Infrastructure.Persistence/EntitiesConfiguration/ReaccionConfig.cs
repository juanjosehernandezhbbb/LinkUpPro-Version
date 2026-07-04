using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using LinkUp.Core.Domain.Entities;
using LinkUp.Core.Domain.Enums;
using LinkUp.Core.Domain.Common;

namespace LinkUp.Infrastructure.Persistence.EntitiesConfiguration;

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

        builder.HasQueryFilter(r => !r.IsDeleted);
    }
}