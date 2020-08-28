using IdentityDeveloperTemplates.AzureADB2C.WebApp.Authorization.Model;
using IdentityDeveloperTemplates.AzureADB2C.WebApp.Authorization.Services.Interfaces;
using IdentityDeveloperTemplates.AzureADB2C.WebApp.Configuration.Interfaces;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace IdentityDeveloperTemplates.AzureADB2C.WebApp.Authorization.Services
{
    public class AuthorizationGroupService : IAuthorizationGroupService
    {
        private readonly IAuthorizationServiceConfiguration _authorizationServiceConfiguration;
        private readonly HttpClient _httpClient;

        public AuthorizationGroupService(IAuthorizationServiceConfiguration authorizationServiceConfiguration, HttpClient httpClient)
        {
            _authorizationServiceConfiguration = authorizationServiceConfiguration;
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<AuthorizationGroup>> GetAuthorizationGroups()
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, _authorizationServiceConfiguration.Url);
            HttpResponseMessage response = await _httpClient.SendAsync(request);

            if (!response.IsSuccessStatusCode)
            {
                string error = await response.Content.ReadAsStringAsync();
                throw new HttpRequestException(error);
            }

            else
            {
                var stringResponse = await response.Content.ReadAsStringAsync();
                var authorizationGroups = JsonConvert.DeserializeObject<IEnumerable<AuthorizationGroup>>(stringResponse);
                return authorizationGroups;
            }
        }
    }
}
