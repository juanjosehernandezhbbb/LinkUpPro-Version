using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LinkUp.Core.Domain.Enums;

namespace LinkUp.Core.Application.DTOs.Battleship;

public class AtaqueResponseDto
{
    public bool EsTurnoValido { get; set; }
    public string Mensaje { get; set; } = null!;
    public ResultadoAtaque Resultado { get; set; }

    // Si el ataque hundió el último barco, el juego termina
    public bool PartidaTerminada { get; set; }
    public string? GanadorId { get; set; }
}
