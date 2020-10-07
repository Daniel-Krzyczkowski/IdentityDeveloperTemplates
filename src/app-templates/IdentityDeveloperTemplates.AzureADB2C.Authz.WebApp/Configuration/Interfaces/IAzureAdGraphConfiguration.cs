namespace IdentityDeveloperTemplates.AzureADB2C.Authz.WebApp.Configuration.Interfaces
{
    internal interface IAzureAdGraphConfiguration
    {
        public string AzureAdB2CTenant { get; set; }
        public string SignUpSignInPolicyId { get; set; }
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string ApiUrl { get; set; }
        public string ApiVersion { get; set; }
    }
}
