namespace LinkUpPro.Domain.Entities;

public class Publicacion
{
    public int Id { get; set; }

    public string AutorId { get; set; }
    public ApplicationUser Autor { get; set; }

    public string Contenido { get; set; }
    public TipoContenido TipoContenido { get; set; }
    public string? ImagenUrl { get; set; }
    public string? YoutubeUrl { get; set; }
    public Privacidad Privacidad { get; set; }
    public bool PermiteComentarios { get; set; }

    public DateTime FechaCreacion { get; set; }
    public DateTime? FechaModificacion { get; set; }
    public bool EstaEliminada { get; set; }

    public ICollection<Comentario> Comentarios { get; set; } = new List<Comentario>();
    public ICollection<Reaccion> Reacciones { get; set; } = new List<Reaccion>();
    public ICollection<Notificacion> Notificaciones { get; set; } = new List<Notificacion>();
}
