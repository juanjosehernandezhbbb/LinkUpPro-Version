using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LinkUp.Core.Domain.Enums;

namespace LinkUp.Core.Application.DTOs.Posts;

public class CrearPublicacionDto
{
    public string AutorId { get; set; } = null!;
    public string Contenido { get; set; } = null!;
    public Privacidad Privacidad { get; set; }

    public TipoContenido TipoContenido { get; set; }

    public string? VideoYouTubeUrl { get; set; }

 
    public string? ImagenUrl { get; set; }
}