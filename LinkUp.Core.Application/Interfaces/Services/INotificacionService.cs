using LinkUp.Core.Application.DTOs.Profile;
using LinkUp.Core.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkUp.Core.Application.Interfaces.Services;

public interface INotificacionService
{
    Task<IReadOnlyList<NotificacionDto>> GetNoLeidasAsync(string usuarioId);
    Task MarcarComoLeidaAsync(int notificacionId, string usuarioId);

    // ◄ Adaptado a la entidad: Recibe Actor, Destinatario y los IDs de los recursos
    Task CrearNotificacionAsync(string destinatarioId, string actorId, TipoNotificacion tipo, int? publicacionId = null, int? comentarioId = null);
}