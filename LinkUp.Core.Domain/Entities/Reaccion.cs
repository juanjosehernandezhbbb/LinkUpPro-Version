namespace LinkUpPro.Domain.Entities;

public class Reaccion
{
    public int Id { get; set; }

    public int PublicacionId { get; set; }
    public Publicacion Publicacion { get; set; }

    public string UsuarioId { get; set; }
    public ApplicationUser Usuario { get; set; }

    public TipoReaccion Tipo { get; set; }
    public DateTime FechaCreacion { get; set; }
}
