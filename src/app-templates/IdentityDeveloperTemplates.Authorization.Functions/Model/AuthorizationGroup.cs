using Newtonsoft.Json;
using System;

namespace IdentityDeveloperTemplates.Authorization.Functions.Model
{
    public class AuthorizationGroup
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }
        [JsonProperty("groupName")]
        public string GroupName { get; set; }
    }
}
