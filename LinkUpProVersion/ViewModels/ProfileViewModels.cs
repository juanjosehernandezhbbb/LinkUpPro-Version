using System.ComponentModel.DataAnnotations;

namespace LinkUpProVersion.ViewModels
{
    public class ProfileViewModel
    {
        public string Id { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        public string? FotoPerfilUrl { get; set; }
    }

    public class EditProfileViewModel
    {
        [Required]
        [StringLength(50)]
        public string Nombre { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string Apellido { get; set; } = string.Empty;

        public Microsoft.AspNetCore.Http.IFormFile? FotoPerfil { get; set; }

        [DataType(DataType.Password)]
        public string? CurrentPassword { get; set; }

        [DataType(DataType.Password)]
        [StringLength(100, MinimumLength = 8)]
        public string? NewPassword { get; set; }
    }
}
