using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using LinkUp.Core.Domain.Entities;
using LinkUp.Core.Domain.Enums;
using LinkUp.Core.Domain.Common;

namespace LinkUp.Infrastructure.Persistence.EntitiesConfiguration;

public class SolicitudAmistadConfig : IEntityTypeConfiguration<SolicitudAmistad>
{
    public void Configure(EntityTypeBuilder<SolicitudAmistad> builder)
    {
        builder.HasKey(s => s.Id);

        builder.HasOne(s => s.Emisor)
            .WithMany()
            .HasForeignKey(s => s.EmisorId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(s => s.Receptor)
            .WithMany()
            .HasForeignKey(s => s.ReceptorId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(s => new { s.EmisorId, s.ReceptorId })
            .IsUnique()
            .HasFilter("[Estado] = 1"); // 1 = EnEspera. Solo bloquea duplicados mientras esté pendiente en esa misma dirección.

        builder.HasQueryFilter(e => !e.IsDeleted);
    }
}