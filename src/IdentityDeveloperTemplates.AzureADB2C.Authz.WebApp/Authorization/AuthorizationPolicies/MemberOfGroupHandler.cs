using Microsoft.AspNetCore.Authorization;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityDeveloperTemplates.AzureADB2C.WebApp.Authorization.AuthorizationPolicies
{
    public class MemberOfGroupHandler : AuthorizationHandler<MemberOfGroupRequirement>
    {
        protected override Task HandleRequirementAsync(
            AuthorizationHandlerContext context, MemberOfGroupRequirement requirement)
        {
            var groupClaim = context.User.Claims
                                         .FirstOrDefault(claim => claim.Type == "extension_authorization_groups" &&
                                             claim.Value.Equals(requirement.GroupId, StringComparison.InvariantCultureIgnoreCase));

            if (groupClaim != null)
                context.Succeed(requirement);

            return Task.CompletedTask;
        }
    }
}