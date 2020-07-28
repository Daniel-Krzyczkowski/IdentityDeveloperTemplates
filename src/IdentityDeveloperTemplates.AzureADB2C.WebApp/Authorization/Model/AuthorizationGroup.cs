using Newtonsoft.Json;
using System;

namespace IdentityDeveloperTemplates.AzureADB2C.WebApp.Authorization.Model
{
    public class AuthorizationGroup
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }
        [JsonProperty("groupName")]
        public string GroupName { get; set; }
    }
}
