using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeneralMAUI.Models;

namespace GeneralMAUI.Services.Interfaces
{
    public interface IAuthService
    {
        Task<LoginResponse> LoginAsync(UserLogin login);
    }
}
