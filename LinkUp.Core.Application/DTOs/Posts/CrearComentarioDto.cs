using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkUp.Core.Application.DTOs.Posts;

public class CrearComentarioDto
{
    public int PublicacionId { get; set; }
    public string AutorId { get; set; } = null!;
    public string Contenido { get; set; } = null!;
    public int? ParentCommentId { get; set; } 
}
