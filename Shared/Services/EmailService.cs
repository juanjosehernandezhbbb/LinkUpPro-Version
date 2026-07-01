using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LinkUp.Core.Application.Interfaces.Shared;
using System.Diagnostics;

namespace LinkUp.Infrastructure.Shared.Services;

public class EmailService : IEmailService
{
    public Task SendEmailAsync(string to, string subject, string body)
    {
        // Simulación de envío de correo en la consola de depuración de Visual Studio
        Debug.WriteLine("=========================================");
        Debug.WriteLine($"Enviando correo simulado a: {to}");
        Debug.WriteLine($"Asunto: {subject}");
        Debug.WriteLine($"Cuerpo del mensaje: {body}");
        Debug.WriteLine("=========================================");

        return Task.CompletedTask;
    }
}