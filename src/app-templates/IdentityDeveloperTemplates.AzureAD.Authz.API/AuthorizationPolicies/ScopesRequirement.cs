using Microsoft.AspNetCore.Authorization;

namespace IdentityDeveloperTemplates.AzureAD.Authz.API.AuthorizationPolicies
{
    public class ScopesRequirement : IAuthorizationRequirement
    {
        public readonly string ScopeName;

        public ScopesRequirement(string scopeName)
        {
            ScopeName = scopeName;
        }
    }
}
