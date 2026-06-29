using LinkUpPro.Domain.Enums;

namespace LinkUpPro.Domain.Entities;

public class Amistad
{
    public int Id { get; set; }

    public string Usuario1Id { get; set; } = null!;
    public ApplicationUser Usuario1 { get; set; } = null!;

    public string Usuario2Id { get; set; } = null!;
    public ApplicationUser Usuario2 { get; set; } = null!;

    public EstadoAmistad Estado { get; set; }

    public DateTime FechaCreacion { get; set; }
    public DateTime? FechaEliminacion { get; set; }
}
