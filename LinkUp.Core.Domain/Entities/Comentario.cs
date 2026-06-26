namespace LinkUpPro.Domain.Entities;

public class Comentario
{
    public int Id { get; set; }

    // ============================
    // RELACIÓN CON PUBLICACION
    // ============================
    public int PublicacionId { get; set; }
    public Publicacion Publicacion { get; set; } = null!;

    // ============================
    // RELACIÓN CON USUARIO
    // ============================
    public string AutorId { get; set; } = null!;
    public ApplicationUser Autor { get; set; } = null!;

    // ============================
    // AUTO-REFERENCIA (RESPUESTAS)
    // ============================
    public int? ComentarioPadreId { get; set; }
    public Comentario? ComentarioPadre { get; set; }

    public ICollection<Comentario> Respuestas { get; set; } = new List<Comentario>();

    // ============================
    // DATOS
    // ============================
    public string Contenido { get; set; } = null!;
    public DateTime FechaCreacion { get; set; }
    public DateTime? FechaModificacion { get; set; }
    public bool EstaEliminado { get; set; }
}

