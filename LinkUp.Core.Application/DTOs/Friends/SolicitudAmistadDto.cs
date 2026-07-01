using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LinkUp.Core.Domain.Enums;

namespace LinkUp.Core.Application.DTOs.Friends;

public class SolicitudAmistadDto
{
    public int Id { get; set; }
    public string EmisorId { get; set; } = null!;
    public string NombreEmisor { get; set; } = null!;
    public string? FotoEmisorUrl { get; set; }

    public string ReceptorId { get; set; } = null!;
    public EstadoSolicitud Estado { get; set; }
    public DateTime CreatedAt { get; set; }
}
