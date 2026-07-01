using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using LinkUp.Core.Domain.Entities;
using LinkUp.Core.Domain.Enums;
using LinkUp.Core.Domain.Common;

namespace LinkUp.Infrastructure.Persistence.EntitiesConfiguration;

public class NotificacionConfig : IEntityTypeConfiguration<Notificacion>
{
    public void Configure(EntityTypeBuilder<Notificacion> builder)
    {
        builder.HasKey(n => n.Id);

        builder.HasOne(n => n.Destinatario)
            .WithMany()
            .HasForeignKey(n => n.DestinatarioId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(n => n.Actor)
            .WithMany()
            .HasForeignKey(n => n.ActorId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(n => n.Publicacion)
            .WithMany(p => p.Notificaciones)
            .HasForeignKey(n => n.PublicacionId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(n => n.Comentario)
            .WithMany(c => c.Notificaciones)
            .HasForeignKey(n => n.ComentarioId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}