using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LinkUp.Core.Application.DTOs.Account;
using System.Threading.Tasks;

namespace LinkUp.Core.Application.Interfaces
{
    public interface IAccountService
    {
        Task<RegisterResponse> RegisterUserAsync(RegisterRequest request);
    }
}