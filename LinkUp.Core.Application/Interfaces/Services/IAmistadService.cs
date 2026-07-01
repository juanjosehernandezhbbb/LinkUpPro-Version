using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LinkUp.Core.Application.DTOs.Friends;

namespace LinkUp.Core.Application.Interfaces.Services;

public interface IAmistadService
{
    Task<IReadOnlyList<AmigoDto>> GetAmigosPorUsuarioAsync(string usuarioId);
    Task EliminarAmigoAsync(int amistadId, string usuarioId);
}
