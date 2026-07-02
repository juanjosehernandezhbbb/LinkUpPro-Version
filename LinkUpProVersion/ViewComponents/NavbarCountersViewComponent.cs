using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace LinkUpProVersion.ViewComponents;

public class NavbarCountersViewComponent : ViewComponent
{
    private readonly LinkUp.Core.Application.Interfaces.Services.ISolicitudAmistadService _solicitudService;
    private readonly LinkUp.Core.Application.Interfaces.Services.INotificacionService _notificationService;

    public NavbarCountersViewComponent(
        LinkUp.Core.Application.Interfaces.Services.ISolicitudAmistadService solicitudService,
        LinkUp.Core.Application.Interfaces.Services.INotificacionService notificationService)
    {
        _solicitudService = solicitudService;
        _notificationService = notificationService;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var userId = HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
        if (string.IsNullOrEmpty(userId))
        {
            return View(new NavbarCountersViewModel { PendingRequests = 0, UnreadNotifications = 0 });
        }

        var pendientesResult = await _solicitudService.GetPendientesPorUsuarioAsync(userId);
        var pending = pendientesResult.Succeeded && pendientesResult.Data != null ? pendientesResult.Data.Count : 0;

        var noLeidas = await _notificationService.GetNoLeidasAsync(userId);
        var unread = noLeidas?.Count ?? 0;

        return View(new NavbarCountersViewModel { PendingRequests = pending, UnreadNotifications = unread });
    }
}

public class NavbarCountersViewModel
{
    public int PendingRequests { get; set; }
    public int UnreadNotifications { get; set; }
}
