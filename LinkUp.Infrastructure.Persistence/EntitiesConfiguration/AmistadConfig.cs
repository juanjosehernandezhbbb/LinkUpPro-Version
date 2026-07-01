using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using LinkUp.Core.Domain.Entities; 
using LinkUp.Core.Domain.Enums;    
using LinkUp.Core.Domain.Common;

namespace LinkUp.Infrastructure.Persistence.EntitiesConfiguration;

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
            .IsUnique()
            .HasFilter("[IsDeleted] = 0");

        builder.HasQueryFilter(a => !a.IsDeleted);
    }
}