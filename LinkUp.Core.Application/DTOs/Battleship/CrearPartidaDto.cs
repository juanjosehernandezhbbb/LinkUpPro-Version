using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkUp.Core.Application.DTOs.Battleship;

public class CrearPartidaDto
{
    public string Jugador1Id { get; set; } = null!;
    public string Jugador2Id { get; set; } = null!;
}
