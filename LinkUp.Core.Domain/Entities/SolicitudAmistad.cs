using LinkUp.Core.Domain.Common;
using LinkUp.Core.Domain.Enums;

namespace LinkUp.Core.Domain.Entities;

public class SolicitudAmistad : BaseEntity
{
    public string EmisorId { get; set; } = null!;
    public ApplicationUser Emisor { get; set; } = null!;

    public string ReceptorId { get; set; } = null!;
    public ApplicationUser Receptor { get; set; } = null!;

    public EstadoSolicitud Estado { get; set; }

    public bool OcultaParaEmisor { get; set; }

    public DateTime FechaSolicitud { get; set; }
    public DateTime? FechaRespuesta { get; set; }
}
