using System.Globalization;

namespace IdentityDeveloperTemplates.AzureAD.UWP.Config
{
    internal static class AuthenticationServiceConfiguration
    {
        public static readonly string Tenant = "xxx.onmicrosoft.com";
        public static readonly string ClientId = "";
        public static readonly string AzureAdInstance = "https://login.microsoftonline.com/{0}/v2.0";
        public static readonly string Authority = string.Format(CultureInfo.InvariantCulture, AzureAdInstance, Tenant);
        public static readonly string[] ApiScopes = { "api://xxx/.default" };
        public static readonly string RedirectUri = $"msal{ClientId}://auth";
    }
}
