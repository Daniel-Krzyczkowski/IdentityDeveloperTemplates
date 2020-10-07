using IdentityDeveloperTemplates.AzureADB2C.WebApp.Services.Identity;
using IdentityDeveloperTemplates.AzureADB2C.WebApp.Services.Identity.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace IdentityDeveloperTemplates.AzureADB2C.WebApp.Core.DependencyInjection
{
    public static class IdentityServiceCollectionExtensions
    {
        public static IServiceCollection AddIdentityServices(this IServiceCollection services)
        {
            services.AddSingleton<IAzureAdGraphAuthenticationService, AzureAdGraphAuthenticationService>();
            services.AddHttpClient<IAzureAdB2CGraphClientUserService, AzureAdB2CGraphClientUserService>();

            return services;
        }
    }
}
