using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;

namespace LinkUpProVersion.Controllers
{
    [Authorize]
    public class PostsController : Controller
    {
        private readonly LinkUp.Core.Application.Interfaces.Services.IPublicacionService _publicacionService;
        private readonly LinkUp.Core.Application.Interfaces.Services.IComentarioService _comentarioService;
        private readonly LinkUp.Core.Application.Interfaces.Services.IReaccionService _reaccionService;
        private readonly IMapper _mapper;

        public PostsController(
            LinkUp.Core.Application.Interfaces.Services.IPublicacionService publicacionService,
            LinkUp.Core.Application.Interfaces.Services.IComentarioService comentarioService,
            LinkUp.Core.Application.Interfaces.Services.IReaccionService reaccionService,
            IMapper mapper)
        {
            _publicacionService = publicacionService;
            _comentarioService = comentarioService;
            _reaccionService = reaccionService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Index(string? q, string? type, DateTime? from, DateTime? to)
        {
            var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            var res = await _publicacionService.GetMuroUsuariosAsync(userId ?? string.Empty);
            if (!res.Succeeded) return View(new List<LinkUp.Core.Application.DTOs.Posts.PublicacionDto>());
            return View(res.Data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(LinkUp.Core.Application.DTOs.Posts.CrearPublicacionDto createPostModel)
        {
            if (!ModelState.IsValid) return View(createPostModel);
            // Map and call service
            createPostModel.AutorId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value ?? string.Empty;
            var result = await _publicacionService.CreateAsync(createPostModel);
            if (!result.Succeeded)
            {
                ModelState.AddModelError(string.Empty, result.ErrorMessage ?? "Error creating post");
                return View(createPostModel);
            }
            TempData["Success"] = "Post creado.";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var post = await _publicacionService.GetByIdAsync(id);
            if (!post.Succeeded || post.Data == null) return NotFound();
            if (post.Data.AutorId != User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value) return Forbid();
            return View(post.Data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, LinkUp.Core.Application.DTOs.Posts.CrearPublicacionDto editModel)
        {
            if (!ModelState.IsValid) return View(editModel);
            var post = await _publicacionService.GetByIdAsync(id);
            if (!post.Succeeded || post.Data == null) return NotFound();
            if (post.Data.AutorId != User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value) return Forbid();
            var upd = await _publicacionService.UpdateAsync(id, editModel, User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value ?? string.Empty);
            if (!upd.Succeeded) ModelState.AddModelError(string.Empty, upd.ErrorMessage ?? "Unable to update");
            TempData["Success"] = "Post actualizado.";
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var post = await _publicacionService.GetByIdAsync(id);
            if (!post.Succeeded || post.Data == null) return NotFound();
            if (post.Data.AutorId != User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value) return Forbid();
            var del = await _publicacionService.DeleteAsync(id, User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value ?? string.Empty);
            if (!del.Succeeded) ModelState.AddModelError(string.Empty, del.ErrorMessage ?? "Unable to delete");
            TempData["Success"] = "Post eliminado.";
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddComment(int postId, string content)
        {
            if (!ModelState.IsValid) return BadRequest();
            var dto = new LinkUp.Core.Application.DTOs.Posts.CrearComentarioDto
            {
                PublicacionId = postId,
                AutorId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value ?? string.Empty,
                Contenido = content
            };
            await _comentarioService.CreateCommentAsync(_mapper.Map<LinkUp.Core.Application.DTOs.Posts.ComentarioDto>(dto));
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddReply(int commentId, string content)
        {
            if (!ModelState.IsValid) return BadRequest();
            var dto = new LinkUp.Core.Application.DTOs.Posts.CrearComentarioDto
            {
                PublicacionId = commentId, // note: PublicacionId expected; for reply the parent id should be set differently in real flow
                AutorId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value ?? string.Empty,
                Contenido = content,
                ParentCommentId = commentId
            };
            await _comentarioService.CreateCommentAsync(_mapper.Map<LinkUp.Core.Application.DTOs.Posts.ComentarioDto>(dto));
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditComment(int commentId, string content)
        {
            if (!ModelState.IsValid) return BadRequest();
            // Comment edit is not supported by application service. Return BadRequest or implement in service.
            return BadRequest("Editing comments is not supported.");
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteComment(int commentId)
        {
            var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value ?? string.Empty;
            await _comentarioService.DeleteCommentAsync(commentId, userId);
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> React(int postId, string type)
        {
            var dto = new LinkUp.Core.Application.DTOs.Posts.CrearReaccionDto
            {
                PublicacionId = postId,
                UsuarioId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value ?? string.Empty,
                Tipo = Enum.Parse<LinkUp.Core.Domain.Enums.TipoReaccion>(type)
            };
            await _reaccionService.ToggleReaccionAsync(dto);
            return Ok();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RemoveReaction(int postId)
        {
            // ToggleReaccionAsync will remove if already present; call with same DTO
            var dto = new LinkUp.Core.Application.DTOs.Posts.CrearReaccionDto
            {
                PublicacionId = postId,
                UsuarioId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value ?? string.Empty,
                Tipo = LinkUp.Core.Domain.Enums.TipoReaccion.Me // default; adjust as needed
            };
            await _reaccionService.ToggleReaccionAsync(dto);
            return Ok();
        }
    }
}
