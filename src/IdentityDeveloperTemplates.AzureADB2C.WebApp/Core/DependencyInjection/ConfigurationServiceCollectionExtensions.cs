using IdentityDeveloperTemplates.AzureADB2C.WebApp.Configuration;
using IdentityDeveloperTemplates.AzureADB2C.WebApp.Configuration.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace IdentityDeveloperTemplates.AzureADB2C.WebApp.Core.DependencyInjection
{
    public static class ConfigurationServiceCollectionExtensions
    {
        public static IServiceCollection AddAzureAdGraphConfiguration(this IServiceCollection services, IConfiguration config)
        {
            services.Configure<AzureAdGraphConfiguration>(config.GetSection("AzureAdB2C"));
            services.AddSingleton<IValidateOptions<AzureAdGraphConfiguration>, CosmosDbDataServiceConfigurationValidation>();
            var azureAdGraphConfiguration = services.BuildServiceProvider().GetRequiredService<IOptions<AzureAdGraphConfiguration>>().Value;
            services.AddSingleton<IAzureAdGraphConfiguration>(azureAdGraphConfiguration);

            return services;
        }
    }
}
