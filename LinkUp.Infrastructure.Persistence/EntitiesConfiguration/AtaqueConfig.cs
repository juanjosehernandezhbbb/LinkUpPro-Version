using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using LinkUp.Core.Domain.Entities;
using LinkUp.Core.Domain.Enums;
using LinkUp.Core.Domain.Common;

namespace LinkUp.Infrastructure.Persistence.EntitiesConfiguration;

public class AtaqueConfig : IEntityTypeConfiguration<Ataque>
{
    public void Configure(EntityTypeBuilder<Ataque> builder)
    {
        builder.HasKey(a => a.Id);

        builder.HasOne(a => a.Partida)
            .WithMany()
            .HasForeignKey(a => a.PartidaId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(a => a.Atacante)
            .WithMany()
            .HasForeignKey(a => a.AtacanteId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(a => new { a.PartidaId, a.AtacanteId, a.Fila, a.Columna })
            .IsUnique();
    }
}