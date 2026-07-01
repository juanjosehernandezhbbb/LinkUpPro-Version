using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LinkUp.Core.Application.Interfaces.Shared;

namespace LinkUp.Infrastructure.Shared.Services;

public class FileStorageService : IFileStorageService
{
    public async Task<string> SaveFileAsync(Stream fileStream, string extension, string containerName)
    {
        var fileName = $"{Guid.NewGuid()}{extension}";

        var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", containerName);

        if (!Directory.Exists(folderPath))
        {
            Directory.CreateDirectory(folderPath);
        }

        var filePath = Path.Combine(folderPath, fileName);

        using (var outputStream = new FileStream(filePath, FileMode.Create))
        {
            await fileStream.CopyToAsync(outputStream);
        }

        return $"/{containerName}/{fileName}";
    }

    public Task RemoveFileAsync(string fileRoute, string containerName)
    {
        if (string.IsNullOrEmpty(fileRoute)) return Task.CompletedTask;

        var fileName = Path.GetFileName(fileRoute);
        var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", containerName, fileName);

        if (File.Exists(filePath))
        {
            File.Delete(filePath);
        }

        return Task.CompletedTask;
    }
}
