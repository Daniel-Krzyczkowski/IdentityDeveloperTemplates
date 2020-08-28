using Microsoft.AspNetCore.Authorization;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityDeveloperTemplates.AzureAD.Authz.API.AuthorizationPolicies
{
    public class MemberOfGroupHandler : AuthorizationHandler<MemberOfGroupRequirement>
    {
        protected override Task HandleRequirementAsync(
            AuthorizationHandlerContext context, MemberOfGroupRequirement requirement)
        {
            var groupClaim = context.User.Claims
                 .FirstOrDefault(claim => claim.Type == "groups" &&
                     claim.Value.Equals(requirement.GroupId, StringComparison.InvariantCultureIgnoreCase));

            if (groupClaim != null)
                context.Succeed(requirement);

            return Task.CompletedTask;
        }
    }
}