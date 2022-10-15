using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using WebbgameUi.Services.AuthService;

namespace WebbgameUi.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureServiceManager(this IServiceCollection services)
        {
            //services.AddScoped<IRequestService, RequestService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddBlazoredLocalStorage();
            services.AddOptions();
            services.AddAuthorizationCore();
            services.AddScoped<AuthenticationStateProvider, CustomerAuthStateProvider>();
        }
    }
}
