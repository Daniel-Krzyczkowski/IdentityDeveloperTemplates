using IdentityDeveloperTemplates.Authorization.Functions.Configuration;
using IdentityDeveloperTemplates.Authorization.Functions.Configuration.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace IdentityDeveloperTemplates.Authorization.Functions.Core.DependencyInjection
{
    internal static class ConfigurationServiceCollectionExtensions
    {
        public static IServiceCollection AddAppConfiguration(this IServiceCollection services, IConfiguration config)
        {
            services.Configure<AzureSqlDatabaseConfiguration>(config.GetSection("AzureSqlDatabase"));
            var azureSqlDatabaseConfiguration = services
                                                    .BuildServiceProvider()
                                                    .GetRequiredService<IOptions<AzureSqlDatabaseConfiguration>>()
                                                    .Value;
            services.AddSingleton<IAzureSqlDatabaseConfiguration>(azureSqlDatabaseConfiguration);

            return services;
        }
    }
}
