using IdentityDeveloperTemplates.Authorization.Functions.Core.DependencyInjection;
using IdentityDeveloperTemplates.Authorization.Functions.Queries;
using IdentityDeveloperTemplates.Authorization.Functions.Queries.Interfaces;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;


[assembly: FunctionsStartup(typeof(IdentityDeveloperTemplates.Authorization.Functions.Startup))]
namespace IdentityDeveloperTemplates.Authorization.Functions
{
    internal class Startup : FunctionsStartup
    {
        private IConfiguration _configuration;

        public override void Configure(IFunctionsHostBuilder builder)
        {
            ConfigureSettings(builder);
            builder.Services.AddTransient<IAuthorizationQueries, AuthorizationQueries>();
        }

        private void ConfigureSettings(IFunctionsHostBuilder builder)
        {
            var config = new ConfigurationBuilder()
               .SetBasePath(Environment.CurrentDirectory)
               .AddJsonFile("local.settings.json", optional: true, reloadOnChange: true)
               .AddEnvironmentVariables()
               .Build();
            _configuration = config;

            builder.Services.AddAppConfiguration(_configuration);
        }
    }
}