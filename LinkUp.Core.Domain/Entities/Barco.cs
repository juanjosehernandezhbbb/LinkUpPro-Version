using LinkUp.Core.Domain.Common;
using LinkUp.Core.Domain.Enums;


namespace LinkUp.Core.Domain.Entities;

public class Barco : BaseEntity
{
    public int Id { get; set; }

    public int PartidaId { get; set; }
    public PartidaBattleship Partida { get; set; }

    public string PropietarioId { get; set; }
    public ApplicationUser Propietario { get; set; }

    public int Tamano { get; set; }

    public int FilaInicio { get; set; }
    public int ColumnaInicio { get; set; }

    public Direccion Direccion { get; set; }

    public ICollection<CeldaBarco> Celdas { get; set; } = new List<CeldaBarco>();
}
