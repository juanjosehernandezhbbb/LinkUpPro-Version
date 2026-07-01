using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkUp.Core.Application.DTOs.Battleship;

public class RealizarAtaqueDto
{
    public int PartidaId { get; set; }
    public string AtacanteId { get; set; } = null!;

    // Coordenadas del misil
    public int Fila { get; set; }
    public int Columna { get; set; }
}
