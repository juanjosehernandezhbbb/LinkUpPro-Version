using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using LinkUpPro.Domain.Entities;

namespace LinkUpPro.Infrastructure.Persistances.EntitiesConfiguration;

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