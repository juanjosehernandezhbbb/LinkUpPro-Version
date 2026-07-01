using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LinkUp.Core.Application.DTOs.Posts;

namespace LinkUp.Core.Application.Interfaces.Services;

public interface IComentarioService
{
    Task<IReadOnlyList<ComentarioDto>> GetComentariosPorPublicacionAsync(int publicacionId);
    Task<ComentarioDto> CreateCommentAsync(ComentarioDto dto);
    Task DeleteCommentAsync(int commentId, string usuarioId); 
}
