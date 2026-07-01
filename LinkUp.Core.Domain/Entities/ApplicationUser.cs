
namespace LinkUp.Core.Domain.Entities;

public class ApplicationUser 
{
    public string Id { get; set; } = null!;
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public string Telefono { get; set; }
    public string? FotoPerfilUrl { get; set; }
    public DateTime FechaRegistro { get; set; }
}
