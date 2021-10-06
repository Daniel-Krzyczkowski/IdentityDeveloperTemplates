using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Identity.Client;
using System;

namespace IdentityDeveloperTemplates.ClientCredentialsAdB2C.FuncApp
{
    public class Program
    {
        public static void Main()
        {
            var host = new HostBuilder()
                .ConfigureFunctionsWorkerDefaults()
                .ConfigureServices(s =>
                {
                    RegisterDependencies(s);
                })
                .Build();

            host.Run();
        }

        private static void RegisterDependencies(IServiceCollection services)
        {
            var config = new ConfigurationBuilder()
               .SetBasePath(Environment.CurrentDirectory)
               .AddJsonFile("local.settings.json", optional: true, reloadOnChange: true)
               .AddEnvironmentVariables()
               .Build();

            services.Configure<AzureAdB2cSettings>(config.GetSection("AzureAdB2C"));

            services.AddScoped(implementationFactory =>
            {
                var confidentialClient = ConfidentialClientApplicationBuilder.Create(config["AzureAdB2C:ClientId"])
                    .WithClientSecret(config["AzureAdB2C:ClientSecret"])
                    .WithAuthority(config["AzureAdB2C:Authority"])
                    .WithRedirectUri(config["AzureAdB2C:RedirectUri"])
                    .Build();

                return confidentialClient;
            });

            services.AddHttpClient();
        }
    }
}