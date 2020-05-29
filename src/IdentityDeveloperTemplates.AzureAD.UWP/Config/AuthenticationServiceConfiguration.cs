using System.Globalization;

namespace IdentityDeveloperTemplates.AzureAD.UWP.Config
{
    internal static class AuthenticationServiceConfiguration
    {
        public static readonly string Tenant = "";
        public static readonly string ClientId = "";
        public static readonly string AzureAdInstance = "https://login.microsoftonline.com/{0}/v2.0";
        public static readonly string Authority = string.Format(CultureInfo.InvariantCulture, AzureAdInstance, Tenant);
        public static readonly string[] ApiScopes = { "" };
        public static readonly string RedirectUri = "";
    }
}
