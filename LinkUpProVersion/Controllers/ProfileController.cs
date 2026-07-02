using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using LinkUp.Infrastructure.Identity.Entities;
using LinkUpProVersion.ViewModels;
using LinkUp.Core.Application.Interfaces.Shared;

namespace LinkUpProVersion.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IFileStorageService _fileStorage;

        public ProfileController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IFileStorageService fileStorage)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _fileStorage = fileStorage;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null) return Challenge();
            var vm = new ProfileViewModel
            {
                Id = user.Id,
                UserName = user.UserName ?? string.Empty,
                Nombre = user.Nombre,
                Apellido = user.Apellido,
                FotoPerfilUrl = user.FotoPerfilUrl
            };
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditProfileViewModel model)
        {
            if (!ModelState.IsValid) return View(model);
            var user = await _userManager.GetUserAsync(User);
            if (user == null) return Challenge();

            user.Nombre = model.Nombre;
            user.Apellido = model.Apellido;

            if (model.FotoPerfil != null)
            {
                using var stream = model.FotoPerfil.OpenReadStream();
                var ext = System.IO.Path.GetExtension(model.FotoPerfil.FileName);
                var url = await _fileStorage.SaveFileAsync(stream, ext, "profile-images");
                user.FotoPerfilUrl = url;
            }

            var upd = await _userManager.UpdateAsync(user);
            if (!upd.Succeeded)
            {
                ModelState.AddModelError(string.Empty, "Unable to update profile.");
                return View(model);
            }

            if (!string.IsNullOrEmpty(model.NewPassword))
            {
                if (string.IsNullOrEmpty(model.CurrentPassword))
                {
                    ModelState.AddModelError(string.Empty, "Current password required to change password.");
                    return View(model);
                }
                var change = await _userManager.ChangePasswordAsync(user, model.CurrentPassword, model.NewPassword);
                if (!change.Succeeded)
                {
                    foreach (var e in change.Errors) ModelState.AddModelError(string.Empty, e.Description);
                    return View(model);
                }

                // Invalidate other sessions by updating security stamp and signing out
                await _userManager.UpdateSecurityStampAsync(user);
                await _signInManager.SignOutAsync();
                TempData["Success"] = "Password changed. Please login again.";
                return RedirectToAction("Login", "Account");
            }

            TempData["Success"] = "Profile updated.";
            return RedirectToAction("Index");
        }
    }
}
