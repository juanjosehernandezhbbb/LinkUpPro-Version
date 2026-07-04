using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LinkUp.Core.Application.DTOs.Account;
using LinkUp.Core.Application.Interfaces;
using LinkUp.Core.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace LinkUp.Infrastructure.Identity.Services
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public AccountService(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<RegisterResponse> RegisterUserAsync(RegisterRequest request)
        {
            var response = new RegisterResponse { HasError = false };

            // 1. Validar si el username o email ya existen
            var existingUserByEmail = await _userManager.FindByEmailAsync(request.Email);
            if (existingUserByEmail != null)
            {
                response.HasError = true;
                response.Error = "Este correo electronico ya se encuentra registrado.";
                return response;
            }

            var existingUserByName = await _userManager.FindByNameAsync(request.UserName);
            if (existingUserByName != null)
            {
                response.HasError = true;
                response.Error = "Este nombre de usuario ya se encuentra registrado.";
                return response;
            }

            // 2. Mapear al usuario de Identity
            var user = new ApplicationUser
            {
                UserName = request.UserName,
                Email = request.Email,
                Nombre = request.Nombre,
                Apellido = request.Apellido,
                Telefono = request.Telefono, // Propiedad de tu ApplicationUser
                PhoneNumber = request.Telefono, // Propiedad base de IdentityUser
                FechaRegistro = DateTime.Now,
                EmailConfirmed = false // Regla del documento: nace inactiva
            };

            // 3. Crear el usuario en la BD
            var result = await _userManager.CreateAsync(user, request.Password);

            if (!result.Succeeded)
            {
                response.HasError = true;
                response.Error = result.Errors.FirstOrDefault()?.Description;
                return response;
            }

            // 4. Generar el Token de activacion
            response.UserId = user.Id;
            response.ActivationToken = await _userManager.GenerateEmailConfirmationTokenAsync(user);

            return response;
        }
    }
}