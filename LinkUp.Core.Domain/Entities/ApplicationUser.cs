using Microsoft.AspNetCore.Identity;

namespace LinkUp.Core.Domain.Entities;
public class ApplicationUser : IdentityUser
{
    public string Nombre { get; set; } = null!;
    public string Apellido { get; set; } = null!;
    public string Telefono { get; set; } = null!;
    public string? FotoPerfilUrl { get; set; }
    public DateTime FechaRegistro { get; set; }
}