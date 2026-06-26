using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using LinkUpPro.Domain.Entities;

namespace LinkUpPro.Infrastructure.Persistances.EntitiesConfiguration;

public class AmistadConfig : IEntityTypeConfiguration<Amistad>
{
    public void Configure(EntityTypeBuilder<Amistad> builder)
    {
        builder.HasKey(a => a.Id);

        builder.HasOne(a => a.Usuario1)
            .WithMany()
            .HasForeignKey(a => a.Usuario1Id)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(a => a.Usuario2)
            .WithMany()
            .HasForeignKey(a => a.Usuario2Id)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(a => new { a.Usuario1Id, a.Usuario2Id })
            .IsUnique();
    }
}