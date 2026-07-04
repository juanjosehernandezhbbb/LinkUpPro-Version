using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using LinkUp.Core.Domain.Enums;
using System.Collections.Generic;
using System.Linq;

namespace LinkUp.Web.ViewModels
{
    public class PublicacionViewModel : IValidatableObject
    {
        public int? Id { get; set; } // Opcional para edición

        [Required(ErrorMessage = "Debe ingresar el contenido de la publicación.")]
        [StringLength(1000, ErrorMessage = "El contenido debe tener un máximo de 1,000 caracteres.")]
        public string Contenido { get; set; }

        [Required(ErrorMessage = "El tipo de contenido es requerido.")]
        public TipoContenido TipoContenido { get; set; }

        // Archivo para cuando es Imagen
        public IFormFile? ArchivoImagen { get; set; }

        // Enlace para cuando es Video
        public string? YoutubeUrl { get; set; }

        [Required(ErrorMessage = "La privacidad es requerida.")]
        public Privacidad Privacidad { get; set; }

        public bool PermiteComentarios { get; set; } = true;

        // Implementación de IValidatableObject para validaciones complejas
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            // 1. Validar que no sea solo espacios en blanco
            if (!string.IsNullOrWhiteSpace(Contenido) && Contenido.Trim().Length == 0)
            {
                yield return new ValidationResult("El contenido no debe contener únicamente espacios.", new[] { nameof(Contenido) });
            }

            // 2. Validación cruzada por Tipo de Contenido
            if (TipoContenido == TipoContenido.Imagen)
            {
                if (ArchivoImagen == null)
                {
                    yield return new ValidationResult("Debe seleccionar una imagen para crear la publicación.", new[] { nameof(ArchivoImagen) });
                }
                // Nota: La validación de extensión y peso se hará en el controlador o mediante un atributo personalizado
            }
            else if (TipoContenido == TipoContenido.Video)
            {
                if (string.IsNullOrWhiteSpace(YoutubeUrl))
                {
                    yield return new ValidationResult("Debe ingresar un enlace válido de YouTube.", new[] { nameof(YoutubeUrl) });
                }
                // Aquí podrías agregar una regex para validar que sea una URL de YouTube
            }
        }
    }
}