using IdentityDeveloperTemplates.AzureAD.UWP.Authz.Config;
using IdentityDeveloperTemplates.AzureAD.UWP.Authz.Services.Authentication.Interfaces;
using Microsoft.Identity.Client;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityDeveloperTemplates.AzureAD.UWP.Authz.Services.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IPublicClientApplication _publicClientApp;

        public AuthenticationService()
        {
            _publicClientApp = PublicClientApplicationBuilder.Create(AuthenticationServiceConfiguration.ClientId)
                .WithAuthority(AuthenticationServiceConfiguration.Authority)
                .WithRedirectUri(AuthenticationServiceConfiguration.RedirectUri)
                .Build();
        }

        public async Task<AuthenticationData> Authenticate()
        {
            AuthenticationResult authResult = null;
            IEnumerable<IAccount> accounts = await _publicClientApp.GetAccountsAsync();
            try
            {
                authResult = await _publicClientApp.AcquireTokenSilent(AuthenticationServiceConfiguration.ApiScopes, accounts.FirstOrDefault())
                    .ExecuteAsync();
                return new AuthenticationData
                {
                    AccessToken = authResult.AccessToken
                };

            }
            catch (MsalUiRequiredException msalUiRequiredException)
            {
                if (msalUiRequiredException.Message.Contains("No account or login hint was passed to the AcquireTokenSilent call."))
                {
                    authResult = await HandleFirstTimeAuthentication(accounts);
                    if (authResult != null)
                    {
                        return new AuthenticationData
                        {
                            AccessToken = authResult.AccessToken
                        };
                    }
                }

                else
                {
                    System.Diagnostics.Debug.WriteLine(nameof(MsalUiRequiredException) + msalUiRequiredException.Message);
                }
            }

            return null;
        }

        public async Task SignOut()
        {
            IEnumerable<IAccount> accounts = await _publicClientApp
                                                    .GetAccountsAsync()
                                                    .ConfigureAwait(false);
            IAccount firstAccount = accounts.FirstOrDefault();

            try
            {
                await _publicClientApp.RemoveAsync(firstAccount).ConfigureAwait(false);
            }
            catch (MsalException ex)
            {
                System.Diagnostics.Debug.WriteLine(nameof(MsalUiRequiredException) + ex.Message);
            }
        }

        private async Task<AuthenticationResult> HandleFirstTimeAuthentication(IEnumerable<IAccount> accounts)
        {
            try
            {
                AuthenticationResult authResult = await _publicClientApp.AcquireTokenInteractive(AuthenticationServiceConfiguration.ApiScopes)
                     .WithAccount(accounts.FirstOrDefault())
                     .WithPrompt(Prompt.SelectAccount)
                     .ExecuteAsync();
                return authResult;
            }
            catch (MsalException msalClientException)
            {
                if (!msalClientException.ErrorCode.Equals("authentication_canceled"))
                {
                    System.Diagnostics.Debug.WriteLine(nameof(MsalClientException) + msalClientException.Message);
                }

                return null;
            }
        }
    }
}
