using LinkUp.Core.Domain.Entities;
using LinkUpProVersion.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LinkUpProVersion.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public AccountController(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Login(string? returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View(new LoginViewModel());
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model, string? returnUrl = null)
        {
            if (!ModelState.IsValid) return View(model);

            var user = await _userManager.FindByNameAsync(model.UserName);
            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "Usuario no encontrado.");
                return View(model);
            }

            var check = await _signInManager.CheckPasswordSignInAsync(user, model.Password, lockoutOnFailure: true);
            if (!check.Succeeded)
            {
                ModelState.AddModelError(string.Empty, "Credenciales invalidas.");
                return View(model);
            }

            var props = new AuthenticationProperties
            {
                IsPersistent = model.RememberMe,
                ExpiresUtc = model.RememberMe ? DateTimeOffset.UtcNow.AddDays(7) : DateTimeOffset.UtcNow.AddMinutes(30)
            };

            await _signInManager.SignInAsync(user, props);

            // REDIRECCION ACTUALIZADA A DASHBOARD
            return Redirect(returnUrl ?? Url.Action("Index", "Dashboard")!);
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Register() => View(new RegisterViewModel());

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var user = new ApplicationUser
            {
                UserName = model.UserName,
                Email = model.Email,
                Nombre = model.Nombre,
                Apellido = model.Apellido,
                PhoneNumber = model.Telefono,
                Telefono = model.Telefono, // Mapeado para tu ApplicationUser
                FechaRegistro = DateTime.Now, // Mapeado para tu ApplicationUser
                EmailConfirmed = true
            };

            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                TempData["Success"] = "Registro exitoso.";
                return RedirectToAction("Login");
            }

            foreach (var err in result.Errors) ModelState.AddModelError(string.Empty, err.Description);
            return View(model);
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult ForgotPassword() => View(new ForgotPasswordViewModel());

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var user = await _userManager.FindByNameAsync(model.UserName);
            if (user != null) { /* TODO: Logica email */ }

            TempData["Success"] = "Instrucciones enviadas.";
            return RedirectToAction("Login");
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult ResetPassword(string token, string userName)
        {
            return View(new ResetPasswordViewModel { Token = token, UserName = userName });
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var user = await _userManager.FindByNameAsync(model.UserName);
            if (user == null)
            {
                TempData["Error"] = "Usuario no encontrado.";
                return View(model);
            }

            var result = await _userManager.ResetPasswordAsync(user, model.Token, model.NewPassword);
            if (result.Succeeded)
            {
                TempData["Success"] = "Contrasena restablecida.";
                return RedirectToAction("Login");
            }

            foreach (var err in result.Errors) ModelState.AddModelError(string.Empty, err.Description);
            return View(model);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult AccessDenied() => View();
    }
}