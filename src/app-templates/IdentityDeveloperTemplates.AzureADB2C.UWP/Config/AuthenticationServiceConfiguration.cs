namespace IdentityDeveloperTemplates.AzureADB2C.UWP.Config
{
    internal static class AuthenticationServiceConfiguration
    {
        public static string Tenant = "xxx";
        public static string ClientId = "";
        public static string PolicySignUpSignIn = "B2C_1A_SignUpOrSignin";
        public static string BaseAuthority = "https://{tenant}.b2clogin.com/tfp/{tenant}.onmicrosoft.com/{policy}/oauth2/v2.0/authorize";
        public static string Authority = BaseAuthority.Replace("{tenant}", Tenant).Replace("{policy}", PolicySignUpSignIn);
        public static readonly string RedirectUri = $"msal{ClientId}://auth";
        public static string[] ApiScopes = { $"https://{Tenant}.onmicrosoft.com/<<API APP ID FROM THE AZURE AD>>/Access_Identity_API_As_User" };
    }
}
