using IdentityDeveloperTemplates.Authorization.Functions.Model;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace IdentityDeveloperTemplates.Authorization.Functions.DTOs
{
    public class UserAuthorizationGroupsDto
    {
        [JsonProperty("authorizationGroups")]
        public IEnumerable<UserAuthorizationGroup> AuthorizationGroups { get; set; }
    }
}
