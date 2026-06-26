namespace LinkUpPro.Domain.Entities;

public class Amistad
{
    public int Id { get; set; }

    public string Usuario1Id { get; set; }
    public ApplicationUser Usuario1 { get; set; }

    public string Usuario2Id { get; set; }
    public ApplicationUser Usuario2 { get; set; }

    public EstadoAmistad Estado { get; set; }

    public DateTime FechaCreacion { get; set; }
    public DateTime? FechaEliminacion { get; set; }
}
