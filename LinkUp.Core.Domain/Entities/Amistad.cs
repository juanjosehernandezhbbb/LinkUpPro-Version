using LinkUp.Core.Domain.Common;
using LinkUp.Core.Domain.Enums;


namespace LinkUp.Core.Domain.Entities;

public class Amistad : BaseEntity
{
    public string Usuario1Id { get; set; } = null!;
    public ApplicationUser Usuario1 { get; set; } = null!;

    public string Usuario2Id { get; set; } = null!;
    public ApplicationUser Usuario2 { get; set; } = null!;

    public EstadoAmistad Estado { get; set; }

}
