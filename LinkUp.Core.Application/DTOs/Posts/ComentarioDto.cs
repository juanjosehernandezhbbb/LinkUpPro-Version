using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkUp.Core.Application.DTOs.Posts;

public class ComentarioDto
{
    public int Id { get; set; }
    public int PublicacionId { get; set; }

    public string AutorId { get; set; } = null!;
    public string NombreAutor { get; set; } = null!;
    public string? FotoPerfilAutorUrl { get; set; }

    public string Contenido { get; set; } = null!;
    public DateTime CreatedAt { get; set; }

    public int? ParentCommentId { get; set; }
    public bool IsDeleted { get; set; } 
}
