using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using GeneralMAUI.Models;
using GeneralMAUI.Services.Interfaces;

namespace GeneralMAUI.Services
{
    public class AuthService : IAuthService
    {
        private readonly HttpClient _httpClient;

        public AuthService(HttpClient httpClient) 
        { 
            _httpClient = httpClient;
        }
        public async Task<LoginResponse> LoginAsync(UserLogin login)
        {
            //throw new NotImplementedException();

            var response = await _httpClient.PostAsJsonAsync("api/auth/login", login);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<LoginResponse>();
            }
            else
            {
                var error = await response.Content.ReadFromJsonAsync<LoginResponse>();
                throw new Exception(error?.Message ?? "Login failed");
            }
        }
    }
}
