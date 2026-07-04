using System.ComponentModel.DataAnnotations;

namespace LinkUp.Core.Application.DTOs.Account
{
    public class LoginRequest
    {
        [Required(ErrorMessage = "El nombre de usuario es requerido.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "La contraseña es requerida.")]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}