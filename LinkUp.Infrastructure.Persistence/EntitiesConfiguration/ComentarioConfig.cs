using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using LinkUp.Core.Domain.Entities;
using LinkUp.Core.Domain.Enums;
using LinkUp.Core.Domain.Common;

namespace LinkUp.Infrastructure.Persistence.EntitiesConfiguration;

public class ComentarioConfig : IEntityTypeConfiguration<Comentario>
{
    public void Configure(EntityTypeBuilder<Comentario> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Contenido)
            .IsRequired()
            .HasMaxLength(500);

        builder.HasOne(c => c.Publicacion)
            .WithMany()
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

        builder.HasQueryFilter(c => !c.IsDeleted);
    }
}