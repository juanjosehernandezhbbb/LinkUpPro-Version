using LinkUpPro.Domain.Entities;

public class PartidaBattleship
{
    public int Id { get; set; }

    public string Jugador1Id { get; set; } = null!;
    public ApplicationUser Jugador1 { get; set; } = null!;

    public string Jugador2Id { get; set; } = null!;
    public ApplicationUser Jugador2 { get; set; } = null!;

    public EstadoPartida Estado { get; set; }

    public string? TurnoActualUsuarioId { get; set; }
    public ApplicationUser? TurnoActualUsuario { get; set; }

    public string? GanadorId { get; set; }
    public ApplicationUser? Ganador { get; set; } 

    public DateTime? TurnoAsignadoEn { get; set; }

    public DateTime FechaInicio { get; set; }
    public DateTime? FechaFin { get; set; }

    public ICollection<Barco> Barcos { get; set; } = new List<Barco>();
    public ICollection<Ataque> Ataques { get; set; } = new List<Ataque>();
}