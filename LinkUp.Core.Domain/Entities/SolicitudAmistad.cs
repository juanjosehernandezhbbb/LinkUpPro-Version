namespace LinkUpPro.Domain.Entities;

public class SolicitudAmistad
{
    public int Id { get; set; }

    public string EmisorId { get; set; }
    public ApplicationUser Emisor { get; set; }

    public string ReceptorId { get; set; }
    public ApplicationUser Receptor { get; set; }

    public EstadoSolicitud Estado { get; set; }

    public bool OcultaParaEmisor { get; set; }

    public DateTime FechaSolicitud { get; set; }
    public DateTime? FechaRespuesta { get; set; }
}
