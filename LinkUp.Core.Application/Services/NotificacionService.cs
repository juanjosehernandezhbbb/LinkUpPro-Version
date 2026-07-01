using LinkUp.Core.Application.Interfaces.Services;
using LinkUp.Core.Application.DTOs.Profile;
using LinkUp.Core.Domain.Entities;
using LinkUp.Core.Domain.Enums;
using LinkUp.Core.Domain.Interfaces;

namespace LinkUp.Core.Application.Services;

public class NotificacionService : INotificacionService
{
    private readonly IGenericRepository<Notificacion> _repository;
    private readonly IUnitOfWork _unitOfWork;

    public NotificacionService(IGenericRepository<Notificacion> repository, IUnitOfWork unitOfWork)
    {
        _repository = repository; _unitOfWork = unitOfWork;
    }

    public async Task CrearNotificacionAsync(string destinatarioId, string actorId, TipoNotificacion tipo, int? publicacionId = null, int? comentarioId = null)
    {
        var notificacion = new Notificacion
        {
            DestinatarioId = destinatarioId,
            ActorId = actorId,
            Tipo = tipo,
            PublicacionId = publicacionId,
            ComentarioId = comentarioId,
            Leida = false
        };

        await _repository.AddAsync(notificacion);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task<IReadOnlyList<NotificacionDto>> GetNoLeidasAsync(string usuarioId)
    {
        var todas = await _repository.GetAllAsync();

        var noLeidas = todas.Where(n => n.DestinatarioId == usuarioId && !n.Leida && !n.IsDeleted)
                            .OrderByDescending(n => n.CreatedAt)
                            .Select(n => new NotificacionDto
                            {
                                Id = n.Id,
                                UsuarioId = n.DestinatarioId,
                                Tipo = n.Tipo,
                                Mensaje = GenerarMensaje(n.Tipo),
                                UrlRedireccion = n.PublicacionId.HasValue ? $"/Publicacion/Detalle/{n.PublicacionId}" : "#",
                                Leida = n.Leida,
                                CreatedAt = n.CreatedAt
                            }).ToList();

        return noLeidas;
    }

    public async Task MarcarComoLeidaAsync(int notificacionId, string usuarioId)
    {
        var notificacion = await _repository.GetByIdAsync(notificacionId);

        if (notificacion != null && notificacion.DestinatarioId == usuarioId)
        {
            notificacion.Leida = true;
            await _repository.UpdateAsync(notificacion);
            await _unitOfWork.SaveChangesAsync();
        }
    }

    // Helper privado para generar el texto del DTO
    private string GenerarMensaje(TipoNotificacion tipo)
    {
        return tipo switch
        {
            TipoNotificacion.Comentario => "Alguien ha comentado tu publicación.",
            TipoNotificacion.Reaccion => "Alguien ha reaccionado a tu publicación.",
            _ => "Tienes una nueva interacción."
        };
    }
}