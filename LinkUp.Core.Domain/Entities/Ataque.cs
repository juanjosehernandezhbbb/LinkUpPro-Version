using LinkUp.Core.Domain.Common;
using LinkUp.Core.Domain.Enums;

namespace LinkUp.Core.Domain.Entities; 

public class Ataque : BaseEntity
{
    public int PartidaId { get; set; }
    public PartidaBattleship Partida { get; set; } = null!;

    public string AtacanteId { get; set; } = null!;
    public ApplicationUser Atacante { get; set; } = null!;

    public int Fila { get; set; }
    public int Columna { get; set; }

    public ResultadoAtaque Resultado { get; set; }

    public DateTime FechaAtaque { get; set; }
}
