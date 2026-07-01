using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LinkUp.Core.Application.DTOs.Battleship;
using LinkUp.Core.Application.Common;

namespace LinkUp.Core.Application.Interfaces.Services;

public interface IBattleshipService
{
    Task<Result<int>> CrearPartidaAsync(CrearPartidaDto dto);

    Task<Result<AtaqueResponseDto>> AtacarAsync(RealizarAtaqueDto dto);

    Task<Result<bool>> RendirseAsync(int partidaId, string jugadorQueSeRindeId);
}
