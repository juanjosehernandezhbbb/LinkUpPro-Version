using LinkUp.Core.Domain.Common;
using LinkUp.Core.Domain.Enums;


namespace LinkUp.Core.Domain.Entities;

public class Reaccion : BaseEntity
{

    public int PublicacionId { get; set; }
    public Publicacion Publicacion { get; set; }

    public string UsuarioId { get; set; }
    public ApplicationUser Usuario { get; set; }

    public TipoReaccion Tipo { get; set; }
}
