using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LinkUpProVersion.Controllers
{
    [Authorize]
    public class FriendRequestsController : Controller
    {
        private readonly LinkUp.Core.Application.Interfaces.Services.ISolicitudAmistadService _requestService;

        public FriendRequestsController(LinkUp.Core.Application.Interfaces.Services.ISolicitudAmistadService requestService)
        {
            _requestService = requestService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value ?? string.Empty;
            var res = await _requestService.GetPendientesPorUsuarioAsync(userId);
            if (!res.Succeeded) return View(new List<LinkUp.Core.Application.DTOs.Friends.SolicitudAmistadDto>());
            return View(res.Data);
        }

        [HttpGet]
        public IActionResult NewRequest()
        {
            // Listing users to send requests should be implemented in application layer or via UserManager.
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SendRequest(string receptorId)
        {
            var emisor = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value ?? string.Empty;
            var res = await _requestService.EnviarSolicitudAsync(emisor, receptorId);
            if (!res.Succeeded) TempData["Error"] = res.ErrorMessage ?? "No se pudo enviar la solicitud.";
            else TempData["Success"] = "Solicitud enviada.";
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Accept(int solicitudId)
        {
            var receptor = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value ?? string.Empty;
            var res = await _requestService.ResponderSolicitudAsync(solicitudId, receptor, true);
            if (!res.Succeeded) return Forbid();
            TempData["Success"] = "Solicitud aceptada.";
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Reject(int solicitudId)
        {
            var receptor = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value ?? string.Empty;
            var res = await _requestService.ResponderSolicitudAsync(solicitudId, receptor, false);
            if (!res.Succeeded) return Forbid();
            TempData["Success"] = "Solicitud rechazada.";
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Cancel(int solicitudId)
        {
            // Cancel not implemented in application service
            return StatusCode(501, "Cancel not implemented");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult RemoveFromHistory(int solicitudId)
        {
            // RemoveFromHistory not implemented in application service
            return StatusCode(501, "RemoveFromHistory not implemented");
        }
    }
}
