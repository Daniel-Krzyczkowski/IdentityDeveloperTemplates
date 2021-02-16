using System.Globalization;

namespace IdentityDeveloperTemplates.AzureAD.UWP.Config
{
    internal static class AuthenticationServiceConfiguration
    {
        public static readonly string Tenant = "xxx.onmicrosoft.com";
        public static readonly string ClientId = "";
        public static readonly string AzureAdInstance = "https://login.microsoftonline.com/{0}/v2.0";
        public static readonly string Authority = string.Format(CultureInfo.InvariantCulture, AzureAdInstance, Tenant);
        public static readonly string[] ApiScopes = { "https://xxx.onmicrosoft.com/<<API APP ID FROM THE AZURE AD>>/Access_Identity_API_As_User" };
        public static readonly string RedirectUri = $"msal{ClientId}://auth";
    }
}
