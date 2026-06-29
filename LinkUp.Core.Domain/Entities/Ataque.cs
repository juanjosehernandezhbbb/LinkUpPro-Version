using LinkUpPro.Domain.Enums;

namespace LinkUpPro.Domain.Entities;

public class Ataque
{
    public int Id { get; set; }

    public int PartidaId { get; set; }
    public PartidaBattleship Partida { get; set; }

    public string AtacanteId { get; set; }
    public ApplicationUser Atacante { get; set; }

    public int Fila { get; set; }
    public int Columna { get; set; }

    public ResultadoAtaque Resultado { get; set; }

    public DateTime FechaAtaque { get; set; }
}
