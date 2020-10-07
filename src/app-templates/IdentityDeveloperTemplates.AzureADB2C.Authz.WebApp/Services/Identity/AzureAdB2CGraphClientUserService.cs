using IdentityDeveloperTemplates.AzureADB2C.Authz.WebApp.Configuration.Interfaces;
using IdentityDeveloperTemplates.AzureADB2C.Authz.WebApp.Services.Identity.Interfaces;
using IdentityDeveloperTemplates.AzureADB2C.Authz.WebApp.Services.Identity.Model;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace IdentityDeveloperTemplates.AzureADB2C.Authz.WebApp.Services.Identity
{
    internal class AzureAdB2CGraphClientUserService : IAzureAdB2CGraphClientUserService
    {
        private readonly HttpClient _httpClient;
        private readonly IAzureAdGraphAuthenticationService _azureAdGraphAuthenticationService;
        private readonly IAzureAdGraphConfiguration _azureAdGraphConfiguration;

        public AzureAdB2CGraphClientUserService(HttpClient httpClient,
                                                      IAzureAdGraphAuthenticationService azureAdGraphAuthenticationService,
                                                      IAzureAdGraphConfiguration azureAdGraphConfiguration)
        {
            _httpClient = httpClient;
            _azureAdGraphAuthenticationService = azureAdGraphAuthenticationService;
            _azureAdGraphConfiguration = azureAdGraphConfiguration;
        }

        public async Task<AzureAdB2CUser> GetUserByObjectId(string objectId)
        {
            string url = $"{_azureAdGraphConfiguration.ApiUrl}/{_azureAdGraphConfiguration.AzureAdB2CTenant}/users/{objectId}?{_azureAdGraphConfiguration.ApiVersion}";

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, url);
            await _azureAdGraphAuthenticationService.AuthenticateRequestAsync(request);
            HttpResponseMessage response = await _httpClient.SendAsync(request);

            if (!response.IsSuccessStatusCode)
            {
                string error = await response.Content.ReadAsStringAsync();
                throw new Exception($"An error ocurred when getting user profile with Azure AD Graph API: {error}");
            }

            else
            {
                var stringResponse = await response.Content.ReadAsStringAsync();
                var adB2cUser = JsonConvert.DeserializeObject<AzureAdB2CUser>(stringResponse);

                return adB2cUser;
            }
        }

        public async Task<byte[]> GetUserPictureByObjectId(string objectId)
        {
            string url = $"{_azureAdGraphConfiguration.ApiUrl}/{_azureAdGraphConfiguration.AzureAdB2CTenant}/users/{objectId}/thumbnailPhoto?{_azureAdGraphConfiguration.ApiVersion}";

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, url);
            await _azureAdGraphAuthenticationService.AuthenticateRequestAsync(request);
            HttpResponseMessage response = await _httpClient.SendAsync(request);

            if (!response.IsSuccessStatusCode)
            {
                string error = await response.Content.ReadAsStringAsync();
                throw new Exception($"An error ocurred when getting user profile with Azure AD Graph API: {error}");
            }

            else
            {
                var byteArrayResponse = await response.Content.ReadAsByteArrayAsync();
                return byteArrayResponse;
            }
        }
    }
}
