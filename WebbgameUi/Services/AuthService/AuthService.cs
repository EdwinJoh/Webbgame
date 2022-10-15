using SheredHelpers;
using SharedHelpers.DTO;
using System.Net.Http.Json;

namespace WebbgameUi.Services.AuthService
{
    public class AuthService : IAuthService
    {
        private readonly HttpClient _http;

        public AuthService(HttpClient http)
        {
            _http = http;
        }

        public async Task<ServiceResponse<int>> Register(UserForRegistrationDto request)
        {
            var result = await _http.PostAsJsonAsync("api/authentication/register", request);
            return await result.Content.ReadFromJsonAsync<ServiceResponse<int>>();
        }

        public async Task<ServiceResponse<string>> Login(UserForAuthenticationDto request)
        {
            var result = await _http.PostAsJsonAsync("api/authentication/login", request);
            return await result.Content.ReadFromJsonAsync<ServiceResponse<string>>();
        }
    }
}
