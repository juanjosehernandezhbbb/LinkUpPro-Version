using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkUp.Core.Application.Interfaces.Shared;

public interface IFileStorageService
{
    Task<string> SaveFileAsync(Stream fileStream, string extension, string containerName);
    Task RemoveFileAsync(string fileRoute, string containerName);
}
