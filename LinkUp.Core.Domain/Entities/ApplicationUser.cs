using Microsoft.AspNetCore.Identity;

namespace LinkUpPro.Domain.Entities;

public class ApplicationUser : IdentityUser
{
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public string Telefono { get; set; }
    public string? FotoPerfilUrl { get; set; }
    public DateTime FechaRegistro { get; set; }
}
