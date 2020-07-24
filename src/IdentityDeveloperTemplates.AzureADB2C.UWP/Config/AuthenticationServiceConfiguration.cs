namespace IdentityDeveloperTemplates.AzureADB2C.UWP.Config
{
    internal static class AuthenticationServiceConfiguration
    {
        public static string Tenant = "cleanarchdev";
        public static string ClientId = "3b3fdd01-a5c2-4677-87d7-def413906df5";
        public static string PolicySignUpSignIn = "B2C_1_sign_in_or_sign_up";
        public static string BaseAuthority = "https://{tenant}.b2clogin.com/tfp/{tenant}.onmicrosoft.com/{policy}/oauth2/v2.0/authorize";
        public static string Authority = BaseAuthority.Replace("{tenant}", Tenant).Replace("{policy}", PolicySignUpSignIn);
        public static readonly string RedirectUri = $"msal{ClientId}://auth";
        public static string[] ApiScopes = { $"https://{Tenant}.onmicrosoft.com/1dc3cdae-3001-4a21-b0e6-e511a2de02b6/identity_dev_api" };
    }
}
