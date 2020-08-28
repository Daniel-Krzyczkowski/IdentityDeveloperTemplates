using Microsoft.AspNetCore.Authorization;

namespace IdentityDeveloperTemplates.AzureADB2C.WebApp.Authorization.AuthorizationPolicies
{
    public class MemberOfGroupRequirement : IAuthorizationRequirement
    {
        public readonly string GroupId;
        public readonly string GroupName;

        public MemberOfGroupRequirement(string groupName, string groupId)
        {
            GroupName = groupName;
            GroupId = groupId;
        }
    }
}