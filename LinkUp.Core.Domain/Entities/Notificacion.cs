using LinkUpPro.Domain.Entities;
using LinkUpPro.Domain.Enums;

public class Notificacion
{
    public int Id { get; set; }

    public string DestinatarioId { get; set; } = null!;
    public ApplicationUser Destinatario { get; set; } = null!;

    public string ActorId { get; set; } = null!;
    public ApplicationUser Actor { get; set; } = null!;

    public TipoNotificacion Tipo { get; set; }

    public int? PublicacionId { get; set; }
    public Publicacion? Publicacion { get; set; }

    public int? ComentarioId { get; set; }
    public Comentario? Comentario { get; set; }

    public bool Leida { get; set; }
    public DateTime FechaCreacion { get; set; }
}
