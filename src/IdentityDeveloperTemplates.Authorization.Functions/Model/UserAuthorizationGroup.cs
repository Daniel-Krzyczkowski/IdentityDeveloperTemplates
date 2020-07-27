using Newtonsoft.Json;
using System;

namespace IdentityDeveloperTemplates.Authorization.Functions.Model
{
    public class UserAuthorizationGroup
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }
        [JsonProperty("userId")]
        public Guid UserId { get; set; }
        [JsonProperty("groupId")]
        public Guid GroupId { get; set; }
    }
}
