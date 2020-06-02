﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.Identity.Web;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace IdentityDeveloperTemplates.AzureADB2C.API.AuthorizationPolicies
{
    public class ScopesHandler : AuthorizationHandler<ScopesRequirement>
    {
        /// <summary>
        /// AuthorizationHandler that will check if the scope claim has at least one of the requirement values
        /// </summary>
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context,
                                                        ScopesRequirement requirement)
        {
            // If there are no scopes, do not process
            if (!context.User.Claims.Any(x => x.Type == ClaimConstants.Scope)
               && !context.User.Claims.Any(y => y.Type == ClaimConstants.Scp))
            {
                return Task.CompletedTask;
            }

            Claim scopeClaim = context?.User?.FindFirst(ClaimConstants.Scp);

            if (scopeClaim == null)
                scopeClaim = context?.User?.FindFirst(ClaimConstants.Scope);

            if (scopeClaim != null && scopeClaim.Value.Equals(requirement.ScopeName, StringComparison.InvariantCultureIgnoreCase))
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
