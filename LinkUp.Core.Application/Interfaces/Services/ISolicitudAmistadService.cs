using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinkUp.Core.Application.DTOs.Friends;
using LinkUp.Core.Application.Common;

namespace LinkUp.Core.Application.Interfaces.Services;

public interface ISolicitudAmistadService
{
    Task<Result<IReadOnlyList<SolicitudAmistadDto>>> GetPendientesPorUsuarioAsync(string usuarioId);
    Task<Result<bool>> EnviarSolicitudAsync(string emisorId, string receptorId);
    Task<Result<bool>> ResponderSolicitudAsync(int solicitudId, string receptorId, bool aceptar);
}
