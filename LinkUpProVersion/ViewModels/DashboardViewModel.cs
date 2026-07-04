using LinkUp.Core.Domain.Entities;
using LinkUp.Core.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace LinkUp.Web.ViewModels;

public class DashboardViewModel
{
    // 1. Listado de publicaciones a mostrar en el Home
    public IEnumerable<Publicacion> Publicaciones { get; set; } = new List<Publicacion>();

    // 2. Modelo para el formulario de crear publicación (el que validamos hace un momento)
    public PublicacionViewModel NuevaPublicacion { get; set; } = new PublicacionViewModel();

    // 3. Propiedades para los Filtros (opcionales)

    [Display(Name = "Buscar")]
    public string? Busqueda { get; set; }

    [Display(Name = "Tipo de contenido")]
    public TipoContenido? FiltroTipo { get; set; }

    [Display(Name = "Fecha desde")]
    [DataType(DataType.Date)]
    public DateTime? FechaDesde { get; set; }

    [Display(Name = "Fecha hasta")]
    [DataType(DataType.Date)]
    public DateTime? FechaHasta { get; set; }

    [Display(Name = "Estado de edición")]
    public EstadoEdicion? FiltroEdicion { get; set; }
}

// Enum auxiliar para el filtro de edición
public enum EstadoEdicion
{
    Todas,
    Editadas,
    NoEditadas
}