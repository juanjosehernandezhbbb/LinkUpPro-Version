using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LinkUp.Core.Domain.Enums;

namespace LinkUp.Core.Application.DTOs.Posts;

public class CrearReaccionDto
{
    public int PublicacionId { get; set; }
    public string UsuarioId { get; set; } = null!;
    public TipoReaccion Tipo { get; set; }
}
