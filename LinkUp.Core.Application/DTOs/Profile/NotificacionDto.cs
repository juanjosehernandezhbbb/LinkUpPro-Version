using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LinkUp.Core.Domain.Enums;

namespace LinkUp.Core.Application.DTOs.Profile;

public class NotificacionDto
{
    public int Id { get; set; }
    public string UsuarioId { get; set; } = null!;
    public TipoNotificacion Tipo { get; set; }
    public string Mensaje { get; set; } = null!;
    public bool Leida { get; set; }
    public string? UrlRedireccion { get; set; } 
    public DateTime CreatedAt { get; set; }
}
