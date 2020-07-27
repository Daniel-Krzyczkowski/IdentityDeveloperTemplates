using System;

namespace IdentityDeveloperTemplates.Authorization.Functions.Model
{
    public class UserAuthorizationGroup
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid GroupId { get; set; }
    }
}
