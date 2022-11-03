using Entities.Models;
using SheredHelpers;

namespace Service.Contracts;

public interface IAuthenticationService
{
    Task<ServiceResponse<int>> Register(User user, string password);
    Task<bool> UserExist(string email);
    Task<ServiceResponse<string>> Login(string email, string password);

}
