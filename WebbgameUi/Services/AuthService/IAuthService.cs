using SheredHelpers;
using SharedHelpers.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebbgameUi.Services.AuthService
{
    public interface IAuthService
    {
        Task<ServiceResponse<int>> Register(UserForRegistrationDto request);
        Task<ServiceResponse<string>> Login(UserForAuthenticationDto request);
    }
}
