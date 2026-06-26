using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using LinkUpPro.Domain.Entities;

namespace LinkUpPro.Infrastructure.Persistances.EntitiesConfiguration;

public class PublicacionConfig : IEntityTypeConfiguration<Publicacion>
{
    public void Configure(EntityTypeBuilder<Publicacion> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Contenido)
            .IsRequired()
            .HasMaxLength(1000);

        builder.HasOne(p => p.Autor)
            .WithMany()
            .HasForeignKey(p => p.AutorId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}