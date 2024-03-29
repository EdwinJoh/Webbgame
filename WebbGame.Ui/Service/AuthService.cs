﻿using SharedHelpers.DTO.UserDto;
using SheredHelpers;

namespace WebbGame.Ui.Service;

public interface IAuthService
{
    Task<ServiceResponse<string>> Login(UserLogin request);
    Task<ServiceResponse<int>> Register(UserRegister request);
}

public class AuthService : IAuthService
{
    private readonly HttpClient _http;

    public AuthService(HttpClient http)
    {
        _http = http;
    }

    public async Task<ServiceResponse<int>> Register(UserRegister request)
    {
        var result = await _http.PostAsJsonAsync("https://localhost:5001/register/", request);
        return await result.Content.ReadFromJsonAsync<ServiceResponse<int>>();
    }

    public async Task<ServiceResponse<string>> Login(UserLogin request)
    {
        var result = await _http.PostAsJsonAsync("https://localhost:5001/login/", request);
        return await result.Content.ReadFromJsonAsync<ServiceResponse<string>>();
    }
}