using SharedHelpers;
using SharedHelpers.DTO.UserDto;
using SheredHelpers;
using System.Net.Http.Json;

namespace Webbgame.UI.Services.AuthService;
/// <summary>
/// This class sends request to the api when a user want to register or login
/// </summary>
public class AuthService : IAuthService
{
    private readonly HttpClient _http;

    public AuthService(HttpClient http)
    {
        _http = http;
    }

    public async Task<ServiceResponse<int>> Register(UserRegister request)
    {
        var result = await _http.PostAsJsonAsync("api/authentication/register", request);
        return await result.Content.ReadFromJsonAsync<ServiceResponse<int>>();
    }

    public async Task<ServiceResponse<string>> Login(UserLogin request)
    {
        var result = await _http.PostAsJsonAsync("api/authentication/login", request);
        return await result.Content.ReadFromJsonAsync<ServiceResponse<string>>();
    }
}
