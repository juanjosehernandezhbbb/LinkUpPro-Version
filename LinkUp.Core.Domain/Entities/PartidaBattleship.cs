namespace LinkUpPro.Domain.Entities;

public class PartidaBattleship
{
    public int Id { get; set; }

    public string Jugador1Id { get; set; }
    public ApplicationUser Jugador1 { get; set; }

    public string Jugador2Id { get; set; }
    public ApplicationUser Jugador2 { get; set; }

    public EstadoPartida Estado { get; set; }

    public string? TurnoActualUsuarioId { get; set; }
    public ApplicationUser? TurnoActualUsuario { get; set; }

    public string? GanadorId { get; set; }
    public ApplicationUser Ganador { get; set; }

    public DateTime? TurnoAsignadoEn { get; set; }

    public DateTime FechaInicio { get; set; }
    public DateTime? FechaFin { get; set; }

    public ICollection<Barco> Barcos { get; set; } = new List<Barco>();
    public ICollection<Ataque> Ataques { get; set; } = new List<Ataque>();
}
