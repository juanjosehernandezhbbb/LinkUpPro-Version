using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using LinkUp.Core.Domain.Entities;
using LinkUp.Core.Domain.Enums;
using LinkUp.Core.Domain.Common;

namespace LinkUp.Infrastructure.Persistence.EntitiesConfiguration;

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