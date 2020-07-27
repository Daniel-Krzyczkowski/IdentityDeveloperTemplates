using IdentityDeveloperTemplates.AzureADB2C.WebApp.Configuration.Interfaces;

namespace IdentityDeveloperTemplates.AzureADB2C.WebApp.Configuration
{
    internal class AuthorizationGroupsConfiguration : IAuthorizationGroupsConfiguration
    {
        public string GroupName { get; set; }
        public string GroupId { get; set; }
    }
}
