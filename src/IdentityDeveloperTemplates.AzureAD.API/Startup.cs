using IdentityDeveloperTemplates.AzureAD.API.AuthorizationPolicies;
using IdentityDeveloperTemplates.AzureAD.API.Configuration;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Identity.Web;
using Microsoft.Identity.Web.TokenCacheProviders.InMemory;
using System.Collections.Generic;

namespace IdentityDeveloperTemplates.AzureAD.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddProtectedWebApi(Configuration)
                    .AddProtectedWebApiCallsProtectedWebApi(Configuration)
                    .AddInMemoryTokenCaches();

            var azureAdGroupConfig = new List<AzureAdGroupConfig>();
            Configuration.Bind("AzureAdGroups", azureAdGroupConfig);

            services.AddAuthorization(options =>
            {
                foreach (var adGroup in azureAdGroupConfig)
                {
                    options.AddPolicy(
                        adGroup.GroupName,
                        policy =>
                            policy.AddRequirements(new MemberOfGroupRequirement(adGroup.GroupName, adGroup.GroupId)));
                }
            });
            services.AddSingleton<IAuthorizationHandler, MemberOfGroupHandler>();
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
