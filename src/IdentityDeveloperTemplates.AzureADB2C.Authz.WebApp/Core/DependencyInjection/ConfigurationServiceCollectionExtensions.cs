using IdentityDeveloperTemplates.AzureADB2C.Authz.WebApp.Configuration;
using IdentityDeveloperTemplates.AzureADB2C.Authz.WebApp.Configuration.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace IdentityDeveloperTemplates.AzureADB2C.Authz.WebApp.Core.DependencyInjection
{
    public static class ConfigurationServiceCollectionExtensions
    {
        public static IServiceCollection AddAppConfiguration(this IServiceCollection services, IConfiguration config)
        {
            services.Configure<AzureAdGraphConfiguration>(config.GetSection("AzureAdB2C"));
            services.AddSingleton<IValidateOptions<AzureAdGraphConfiguration>, CosmosDbDataServiceConfigurationValidation>();
            var azureAdGraphConfiguration = services.BuildServiceProvider().GetRequiredService<IOptions<AzureAdGraphConfiguration>>().Value;
            services.AddSingleton<IAzureAdGraphConfiguration>(azureAdGraphConfiguration);

            services.Configure<AuthorizationServiceConfiguration>(config.GetSection("AuthorizationService"));
            services.AddSingleton<IValidateOptions<AuthorizationServiceConfiguration>, AuthorizationServiceConfigurationValidation>();
            var authorizationServiceConfiguration = services.BuildServiceProvider().GetRequiredService<IOptions<AuthorizationServiceConfiguration>>().Value;
            services.AddSingleton<IAuthorizationServiceConfiguration>(authorizationServiceConfiguration);

            return services;
        }
    }
}
