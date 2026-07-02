using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LinkUpProVersion.Controllers
{
    [Authorize]
    public class FriendsController : Controller
    {
        private readonly LinkUp.Core.Application.Interfaces.Services.IAmistadService _amistadService;
        private readonly Microsoft.AspNetCore.Identity.UserManager<LinkUp.Infrastructure.Identity.Entities.AppUser> _userManager;

        public FriendsController(LinkUp.Core.Application.Interfaces.Services.IAmistadService amistadService,
            Microsoft.AspNetCore.Identity.UserManager<LinkUp.Infrastructure.Identity.Entities.AppUser> userManager)
        {
            _amistadService = amistadService;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value ?? string.Empty;
            var amigos = await _amistadService.GetAmigosPorUsuarioAsync(userId);
            return View(amigos);
        }

        [HttpGet]
        public async Task<IActionResult> Profile(string username)
        {
            var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value ?? string.Empty;
            var user = await _userManager.FindByNameAsync(username);
            if (user == null) return NotFound();

            var amigos = await _amistadService.GetAmigosPorUsuarioAsync(userId);
            var isFriend = amigos.Any(a => a.AmigoId == user.Id);
            if (!isFriend) return Forbid();

            // Map minimal profile data to view
            var profileVm = new { user.Id, user.UserName, user.Nombre, user.Apellido, user.FotoPerfilUrl };
            return View(profileVm);
        }

        [HttpGet]
        public async Task<IActionResult> ListFriends(string? q)
        {
            var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value ?? string.Empty;
            var amigos = await _amistadService.GetAmigosPorUsuarioAsync(userId);
            if (!string.IsNullOrEmpty(q))
                amigos = amigos.Where(a => a.NombreAmigo.Contains(q, StringComparison.OrdinalIgnoreCase)).ToList();
            return View(amigos);
        }

        [HttpGet]
        public async Task<IActionResult> MutualFriends(int friendId)
        {
            // Application layer does not expose a mutual-friends method. Return NotImplemented for now.
            return StatusCode(501, "Mutual friends not implemented in application layer");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RemoveFriend(int amistadId)
        {
            var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value ?? string.Empty;
            await _amistadService.EliminarAmigoAsync(amistadId, userId);
            TempData["Success"] = "Amigo eliminado.";
            return RedirectToAction("Index");
        }
    }
}
