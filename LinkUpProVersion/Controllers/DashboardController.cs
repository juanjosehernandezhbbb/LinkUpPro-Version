using LinkUp.Core.Domain.Entities;
using LinkUp.Core.Domain.Enums;
using LinkUp.Infrastructure.Persistence.Context;
using LinkUp.Web.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;

[Authorize]
public class DashboardController : Controller
{
    private readonly LinkUpContext _context;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IWebHostEnvironment _env;

    public DashboardController(LinkUpContext context, UserManager<ApplicationUser> userManager, IWebHostEnvironment env)
    {
        _context = context;
        _userManager = userManager;
        _env = env;
    }

    public async Task<IActionResult> Index(string? busqueda)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        // Iniciamos la consulta incluyendo al Autor para evitar errores de referencia nula
        var query = _context.Publicaciones
            .Include(p => p.Autor)
            .Where(p => p.AutorId == userId);

        // Aplicamos el filtro de búsqueda si existe
        if (!string.IsNullOrEmpty(busqueda))
        {
            query = query.Where(p => p.Contenido.Contains(busqueda));
        }

        var publicaciones = await query
            .OrderByDescending(p => p.CreatedAt)
            .ToListAsync();

        var viewModel = new DashboardViewModel
        {
            Publicaciones = publicaciones,
            Busqueda = busqueda // Mantenemos el texto en el input
        };

        return View(viewModel);
    }

    [HttpPost]
    public async Task<IActionResult> Create(PublicacionViewModel model)
    {
        if (!ModelState.IsValid)
        {
            // SI FALLA: Necesitamos recargar la lista de publicaciones 
            // o la vista se romperá al intentar mostrar la lista vacía.
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var posts = await _context.Publicaciones.Include(p => p.Autor).OrderByDescending(p => p.CreatedAt).ToListAsync();

            return View("Index", new DashboardViewModel
            {
                NuevaPublicacion = model,
                Publicaciones = posts
            });
        }

        var userIdActual = User.FindFirstValue(ClaimTypes.NameIdentifier);

        var publicacion = new Publicacion
        {
            AutorId = userIdActual,
            Contenido = model.Contenido,
            TipoContenido = model.TipoContenido,
            Privacidad = model.Privacidad,
            PermiteComentarios = model.PermiteComentarios,
            CreatedAt = DateTime.Now
        };

        if (model.TipoContenido == TipoContenido.Imagen && model.ArchivoImagen != null)
        {
            string uploadsFolder = Path.Combine(_env.WebRootPath, "images/posts");
            if (!Directory.Exists(uploadsFolder)) Directory.CreateDirectory(uploadsFolder);

            string uniqueFileName = Guid.NewGuid().ToString() + "_" + model.ArchivoImagen.FileName;
            string filePath = Path.Combine(uploadsFolder, uniqueFileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await model.ArchivoImagen.CopyToAsync(fileStream);
            }

            publicacion.ImagenUrl = "/images/posts/" + uniqueFileName;
        }
        else if (model.TipoContenido == TipoContenido.Video)
        {
            publicacion.YoutubeUrl = model.YoutubeUrl;
        }

        _context.Publicaciones.Add(publicacion);
        await _context.SaveChangesAsync();

        TempData["Success"] = "La publicación fue creada correctamente.";
        return RedirectToAction("Index");
    }
}