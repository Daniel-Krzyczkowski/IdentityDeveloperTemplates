using IdentityDeveloperTemplates.AzureADB2C.Authz.WebApp.Authorization.AuthorizationPolicies;
using IdentityDeveloperTemplates.AzureADB2C.Authz.WebApp.Authorization.Services;
using IdentityDeveloperTemplates.AzureADB2C.Authz.WebApp.Authorization.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;

namespace IdentityDeveloperTemplates.AzureADB2C.Authz.WebApp.Core.DependencyInjection
{
    public static class AuthorizationServiceCollectionExtensions
    {
        public static IServiceCollection AddAuthorizationServices(this IServiceCollection services)
        {
            services.AddHttpClient<IAuthorizationGroupService, AuthorizationGroupService>();
            var serviceProvider = services.BuildServiceProvider();

            var authorizationService = serviceProvider.GetRequiredService<IAuthorizationGroupService>();

            var authorizationGroups = authorizationService.GetAuthorizationGroups().GetAwaiter().GetResult();

            services.AddAuthorization(options =>
            {
                foreach (var authorizationGroup in authorizationGroups)
                {
                    options.AddPolicy(
                        authorizationGroup.GroupName,
                        policy =>
                            policy.AddRequirements(new MemberOfGroupRequirement(authorizationGroup.GroupName, authorizationGroup.Id.ToString())));
                }
            });

            services.AddSingleton<IAuthorizationHandler, MemberOfGroupHandler>();

            return services;
        }
    }
}
