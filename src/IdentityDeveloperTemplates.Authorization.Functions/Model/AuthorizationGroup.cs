using System;

namespace IdentityDeveloperTemplates.Authorization.Functions.Model
{
    public class AuthorizationGroup
    {
        public Guid Id { get; set; }
        public Guid GroupId { get; set; }
        public string GroupName { get; set; }
    }
}
