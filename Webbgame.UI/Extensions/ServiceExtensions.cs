using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Webbgame.UI.Services;
using Webbgame.UI.Services.AuthService;

namespace Webbgame.UI.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureServiceManager(this IServiceCollection services)
        {
            services.AddScoped<IRequestService, RequestService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddBlazoredLocalStorage();
            services.AddOptions();
            services.AddAuthorizationCore();
            services.AddScoped<AuthenticationStateProvider, CustomerAuthStateProvider>();
        }
    }
}
