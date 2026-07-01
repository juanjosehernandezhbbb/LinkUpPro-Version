
using LinkUp.Core.Domain.Common;

namespace LinkUp.Core.Domain.Entities;

public class CeldaBarco : BaseEntity
{
    public int BarcoId { get; set; }
    public Barco Barco { get; set; }

    public int Fila { get; set; }
    public int Columna { get; set; }

    public bool Impactada { get; set; }
}
