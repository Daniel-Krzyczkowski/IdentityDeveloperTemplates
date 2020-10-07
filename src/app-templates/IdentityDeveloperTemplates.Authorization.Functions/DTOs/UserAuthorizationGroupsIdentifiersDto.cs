using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace IdentityDeveloperTemplates.Authorization.Functions.DTOs
{
    public class UserAuthorizationGroupsIdentifiersDto
    {
        [JsonProperty("authorizationGroups")]
        public IEnumerable<Guid> AuthorizationGroups { get; set; }
    }
}
