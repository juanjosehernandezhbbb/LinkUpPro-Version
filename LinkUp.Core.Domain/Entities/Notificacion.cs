namespace LinkUpPro.Domain.Entities;

public class Notificacion
{
    public int Id { get; set; }

    public string DestinatarioId { get; set; }
    public ApplicationUser Destinatario { get; set; }

    public string ActorId { get; set; }
    public ApplicationUser Actor { get; set; }

    public TipoNotificacion Tipo { get; set; }

    public int? PublicacionId { get; set; }
    public Publicacion Publicacion { get; set; }

    public int? ComentarioId { get; set; }
    public Comentario Comentario { get; set; }

    public bool Leida { get; set; }
    public DateTime FechaCreacion { get; set; }
}
