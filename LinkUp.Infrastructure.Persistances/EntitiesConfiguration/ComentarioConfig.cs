using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using LinkUpPro.Domain.Entities;

namespace LinkUpPro.Infrastructure.Persistances.EntitiesConfiguration;

public class ComentarioConfig : IEntityTypeConfiguration<Comentario>
{
    public void Configure(EntityTypeBuilder<Comentario> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Contenido)
            .IsRequired()
            .HasMaxLength(500);

        builder.HasOne(c => c.Publicacion)
            .WithMany(p => p.Comentarios)
            .HasForeignKey(c => c.PublicacionId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(c => c.Autor)
            .WithMany()
            .HasForeignKey(c => c.AutorId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(c => c.ComentarioPadre)
            .WithMany(c => c.Respuestas)
            .HasForeignKey(c => c.ComentarioPadreId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}