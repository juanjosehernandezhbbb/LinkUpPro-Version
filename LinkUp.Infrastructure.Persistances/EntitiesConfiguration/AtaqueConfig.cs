using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using LinkUpPro.Domain.Entities;

namespace LinkUpPro.Infrastructure.Persistances.EntitiesConfiguration;

public class AtaqueConfig : IEntityTypeConfiguration<Ataque>
{
    public void Configure(EntityTypeBuilder<Ataque> builder)
    {
        builder.HasKey(a => a.Id);

        builder.HasOne(a => a.Partida)
            .WithMany(p => p.Ataques)
            .HasForeignKey(a => a.PartidaId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(a => a.Atacante)
            .WithMany()
            .HasForeignKey(a => a.AtacanteId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}