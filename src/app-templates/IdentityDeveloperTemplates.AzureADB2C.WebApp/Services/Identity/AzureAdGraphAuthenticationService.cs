using IdentityDeveloperTemplates.AzureADB2C.WebApp.Configuration.Interfaces;
using IdentityDeveloperTemplates.AzureADB2C.WebApp.Services.Identity.Interfaces;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace IdentityDeveloperTemplates.AzureADB2C.WebApp.Services.Identity
{
    internal class AzureAdGraphAuthenticationService : IAzureAdGraphAuthenticationService
    {
        private readonly IAzureAdGraphConfiguration _azureAdGraphConfiguration;

        public AzureAdGraphAuthenticationService(IAzureAdGraphConfiguration azureAdGraphConfiguration)
        {
            _azureAdGraphConfiguration = azureAdGraphConfiguration;
        }

        public async Task AuthenticateRequestAsync(HttpRequestMessage request)
        {
            var authContext = new AuthenticationContext($"https://login.microsoftonline.com/{_azureAdGraphConfiguration.AzureAdB2CTenant}");

            var clientCred = new ClientCredential(_azureAdGraphConfiguration.ClientId, _azureAdGraphConfiguration.ClientSecret);

            var authResult = await authContext.AcquireTokenAsync(_azureAdGraphConfiguration.ApiUrl, clientCred);

            if (authResult == null)
            {
                throw new InvalidOperationException("Failed to obtain the JWT token from the Azure AD Graph API");
            }

            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", authResult.AccessToken);
        }
    }
}
