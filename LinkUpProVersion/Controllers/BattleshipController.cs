using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LinkUpProVersion.Controllers
{
    [Authorize]
    public class BattleshipController : Controller
    {
        private readonly LinkUp.Core.Application.Interfaces.Services.IBattleshipService _battleshipService;

        public BattleshipController(LinkUp.Core.Application.Interfaces.Services.IBattleshipService battleshipService)
        {
            _battleshipService = battleshipService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return StatusCode(501, "Battleship overview not implemented in application layer");
        }

        [HttpGet]
        public async Task<IActionResult> NewGame()
        {
            return StatusCode(501, "NewGame (GET) not implemented; use POST to create a game.");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> NewGame(string opponentId)
        {
            var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value ?? string.Empty;
            var dto = new LinkUp.Core.Application.DTOs.Battleship.CrearPartidaDto { Jugador1Id = userId, Jugador2Id = opponentId };
            var res = await _battleshipService.CrearPartidaAsync(dto);
            if (!res.Succeeded) { TempData["Error"] = res.ErrorMessage ?? "No se pudo crear la partida."; return RedirectToAction("Index"); }
            var gameId = res.Data;
            return RedirectToAction("PlaceShips", new { gameId });
        }

        [HttpGet]
        public Task<IActionResult> PlaceShips(int gameId)
        {
            return Task.FromResult<IActionResult>(StatusCode(501, "PlaceShips not implemented in application layer"));
        }

        [HttpGet]
        public Task<IActionResult> SelectCell(int gameId, int shipId)
        {
            return Task.FromResult<IActionResult>(StatusCode(501, "SelectCell not implemented in application layer"));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SelectDirection(int gameId, int shipId, int row, int col, string direction)
        {
            var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            // Placement logic is implemented in application layer; adapt method names if necessary
            // For now, redirect back to PlaceShips
            return RedirectToAction("PlaceShips", new { gameId });
        }

        [HttpGet]
        public Task<IActionResult> AttackBoard(int gameId)
        {
            return Task.FromResult<IActionResult>(StatusCode(501, "AttackBoard not implemented in application layer"));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Attack(int gameId, int row, int col)
        {
            var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value ?? string.Empty;
            var dto = new LinkUp.Core.Application.DTOs.Battleship.RealizarAtaqueDto { PartidaId = gameId, AtacanteId = userId, Fila = row, Columna = col };
            var res = await _battleshipService.AtacarAsync(dto);
            if (!res.Succeeded) return Forbid();
            return RedirectToAction("AttackBoard", new { gameId });
        }

        [HttpGet]
        public Task<IActionResult> MyBoard(int gameId)
        {
            return Task.FromResult<IActionResult>(StatusCode(501, "MyBoard not implemented in application layer"));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Surrender(int gameId)
        {
            var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value ?? string.Empty;
            var res = await _battleshipService.RendirseAsync(gameId, userId);
            if (!res.Succeeded) TempData["Error"] = res.ErrorMessage ?? "Unable to surrender.";
            else TempData["Success"] = "You surrendered the game.";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public Task<IActionResult> History()
        {
            return Task.FromResult<IActionResult>(StatusCode(501, "History not implemented in application layer"));
        }

        [HttpGet]
        public Task<IActionResult> Result(int gameId)
        {
            return Task.FromResult<IActionResult>(StatusCode(501, "Result not implemented in application layer"));
        }
    }
}
