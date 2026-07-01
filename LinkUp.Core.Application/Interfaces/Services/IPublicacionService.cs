using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinkUp.Core.Application.DTOs.Posts;
using LinkUp.Core.Application.Common;

namespace LinkUp.Core.Application.Interfaces.Services;

public interface IPublicacionService
{
    Task<Result<PublicacionDto>> GetByIdAsync(int id);

    Task<Result<IReadOnlyList<PublicacionDto>>> GetMuroUsuariosAsync(string usuarioActualId);

    Task<Result<PublicacionDto>> CreateAsync(CrearPublicacionDto dto);

    Task<Result<bool>> UpdateAsync(int id, CrearPublicacionDto dto, string usuarioId);

    Task<Result<bool>> DeleteAsync(int id, string usuarioId);
}
