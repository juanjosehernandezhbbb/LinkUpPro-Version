using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using LinkUp.Core.Domain.Entities;
using LinkUp.Core.Domain.Enums;
using LinkUp.Core.Domain.Common;

namespace LinkUp.Infrastructure.Persistence.EntitiesConfiguration;

public class BarcoConfig : IEntityTypeConfiguration<Barco>
{
    public void Configure(EntityTypeBuilder<Barco> builder)
    {
        builder.HasKey(b => b.Id);

        builder.HasOne(b => b.Partida)
            .WithMany(p => p.Barcos)
            .HasForeignKey(b => b.PartidaId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(b => b.Propietario)
            .WithMany()
            .HasForeignKey(b => b.PropietarioId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}