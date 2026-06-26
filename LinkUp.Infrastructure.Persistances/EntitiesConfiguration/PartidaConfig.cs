using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using LinkUpPro.Domain.Entities;

namespace LinkUpPro.Infrastructure.Persistances.EntitiesConfiguration;

public class PartidaConfig : IEntityTypeConfiguration<PartidaBattleship>
{
    public void Configure(EntityTypeBuilder<PartidaBattleship> builder)
    {
        builder.HasKey(p => p.Id);

        builder.HasOne(p => p.Jugador1)
            .WithMany()
            .HasForeignKey(p => p.Jugador1Id)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(p => p.Jugador2)
            .WithMany()
            .HasForeignKey(p => p.Jugador2Id)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(p => p.Ganador)
            .WithMany()
            .HasForeignKey(p => p.GanadorId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(p => p.TurnoActualUsuario)
            .WithMany()
            .HasForeignKey(p => p.TurnoActualUsuarioId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}