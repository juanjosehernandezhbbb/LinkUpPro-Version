using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkUp.Core.Application.DTOs.Friends;

public class AmigoDto
{
    public int AmistadId { get; set; }
    public string AmigoId { get; set; } = null!;
    public string NombreAmigo { get; set; } = null!;
    public string? FotoAmigoUrl { get; set; }
    public DateTime AmigosDesde { get; set; }
}
