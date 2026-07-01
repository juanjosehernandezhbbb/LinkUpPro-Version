using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinkUp.Core.Application.DTOs.Posts;
using LinkUp.Core.Application.Common;

namespace LinkUp.Core.Application.Interfaces.Services;

public interface IReaccionService
{
    Task<Result<bool>> ToggleReaccionAsync(CrearReaccionDto dto);
}
