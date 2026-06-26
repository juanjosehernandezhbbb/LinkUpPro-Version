using LinkUpPro.Domain.Entities;

public class SolicitudAmistad
{
    public int Id { get; set; }

    public string EmisorId { get; set; } = null!;
    public ApplicationUser Emisor { get; set; } = null!;

    public string ReceptorId { get; set; } = null!;
    public ApplicationUser Receptor { get; set; } = null!;

    public EstadoSolicitud Estado { get; set; }

    public bool OcultaParaEmisor { get; set; }

    public DateTime FechaSolicitud { get; set; }
    public DateTime? FechaRespuesta { get; set; }
}
