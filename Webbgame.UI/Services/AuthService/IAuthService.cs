using SharedHelpers;
using SharedHelpers.DTO;
using SheredHelpers;

namespace Webbgame.UI.Services.AuthService;
/// <summary>
/// Interface for our authentication for the client side
/// </summary>
public interface IAuthService
{
    Task<ServiceResponse<int>> Register(UserRegister request);
    Task<ServiceResponse<string>> Login(UserLogin request);
}
