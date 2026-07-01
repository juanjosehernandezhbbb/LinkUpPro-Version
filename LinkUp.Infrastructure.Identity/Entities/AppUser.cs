using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkUp.Infrastructure.Identity.Entities
{
    public class AppUser : IdentityUser
    {
        public required string Nombre { get; set; }
        public required string Apellido { get; set; }
        public string? FotoPerfilUrl { get; set; }
    }
}
