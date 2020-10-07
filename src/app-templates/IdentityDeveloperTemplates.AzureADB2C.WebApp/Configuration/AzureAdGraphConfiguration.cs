using IdentityDeveloperTemplates.AzureADB2C.WebApp.Configuration.Interfaces;
using Microsoft.Extensions.Options;

namespace IdentityDeveloperTemplates.AzureADB2C.WebApp.Configuration
{
    internal class AzureAdGraphConfiguration : IAzureAdGraphConfiguration
    {
        public string AzureAdB2CTenant { get; set; }
        public string SignUpSignInPolicyId { get; set; }
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string ApiUrl { get; set; }
        public string ApiVersion { get; set; }
    }

    internal class CosmosDbDataServiceConfigurationValidation : IValidateOptions<AzureAdGraphConfiguration>
    {
        public ValidateOptionsResult Validate(string name, AzureAdGraphConfiguration options)
        {
            if (string.IsNullOrEmpty(options.ApiUrl))
            {
                return ValidateOptionsResult.Fail($"{nameof(options.ApiUrl)} configuration parameter for the Azure Ad Graph is required");
            }

            if (string.IsNullOrEmpty(options.ApiVersion))
            {
                return ValidateOptionsResult.Fail($"{nameof(options.ApiVersion)} configuration parameter for the Azure Ad Graph is required");
            }

            if (string.IsNullOrEmpty(options.AzureAdB2CTenant))
            {
                return ValidateOptionsResult.Fail($"{nameof(options.AzureAdB2CTenant)} configuration parameter for the Azure Ad Graph is required");
            }

            if (string.IsNullOrEmpty(options.ClientId))
            {
                return ValidateOptionsResult.Fail($"{nameof(options.ClientId)} configuration parameter for the Azure Ad Graph is required");
            }

            if (string.IsNullOrEmpty(options.ClientSecret))
            {
                return ValidateOptionsResult.Fail($"{nameof(options.ClientSecret)} configuration parameter for the Azure Ad Graph is required");
            }

            if (string.IsNullOrEmpty(options.SignUpSignInPolicyId))
            {
                return ValidateOptionsResult.Fail($"{nameof(options.SignUpSignInPolicyId)} configuration parameter for the Azure Ad Graph is required");
            }

            return ValidateOptionsResult.Success;
        }
    }
}
