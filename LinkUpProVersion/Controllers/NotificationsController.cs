using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LinkUpProVersion.Controllers
{
    [Authorize]
    public class NotificationsController : Controller
    {
        private readonly LinkUp.Core.Application.Interfaces.Services.INotificacionService _notificationService;

        public NotificationsController(LinkUp.Core.Application.Interfaces.Services.INotificacionService notificationService)
        {
            _notificationService = notificationService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value ?? string.Empty;
            var items = await _notificationService.GetNoLeidasAsync(userId);
            return View(items);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> MarkAsRead(int id)
        {
            var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value ?? string.Empty;
            await _notificationService.MarcarComoLeidaAsync(id, userId);
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> MarkAllAsRead()
        {
            var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value ?? string.Empty;
            var notifs = await _notificationService.GetNoLeidasAsync(userId);
            foreach (var n in notifs)
            {
                await _notificationService.MarcarComoLeidaAsync(n.Id, userId);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult GoToContent(int id)
        {
            // The application service does not expose a redirect URL helper; implement in service if needed.
            return RedirectToAction("Index", "Home");
        }
    }
}
