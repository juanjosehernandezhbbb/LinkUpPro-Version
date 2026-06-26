using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using LinkUpPro.Domain.Entities;

namespace LinkUpPro.Infrastructure.Persistances.EntitiesConfiguration;

public class CeldaBarcoConfig : IEntityTypeConfiguration<CeldaBarco>
{
    public void Configure(EntityTypeBuilder<CeldaBarco> builder)
    {
        builder.HasKey(c => c.Id);

        builder.HasOne(c => c.Barco)
            .WithMany(b => b.Celdas)
            .HasForeignKey(c => c.BarcoId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}