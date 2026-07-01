using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinkUp.Core.Domain.Enums;

namespace LinkUp.Core.Application.DTOs.Posts;

public class PublicacionDto
{
    public int Id { get; set; }
    public string Contenido { get; set; } = null!;
    public Privacidad Privacidad { get; set; }

    public TipoContenido TipoContenido { get; set; }
    public string? ImagenUrl { get; set; }

    public string AutorId { get; set; } = null!;
    public string NombreAutor { get; set; } = null!;
    public string ApellidoAutor { get; set; } = null!;
    public string? FotoPerfilAutorUrl { get; set; }

    public DateTime CreatedAt { get; set; }
}