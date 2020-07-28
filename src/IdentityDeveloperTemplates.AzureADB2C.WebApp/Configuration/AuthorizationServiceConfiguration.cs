using IdentityDeveloperTemplates.AzureADB2C.WebApp.Configuration.Interfaces;
using Microsoft.Extensions.Options;

namespace IdentityDeveloperTemplates.AzureADB2C.WebApp.Configuration
{
    internal class AuthorizationServiceConfiguration : IAuthorizationServiceConfiguration
    {
        public string Url { get; set; }
    }

    internal class AuthorizationServiceConfigurationValidation : IValidateOptions<AuthorizationServiceConfiguration>
    {
        public ValidateOptionsResult Validate(string name, AuthorizationServiceConfiguration options)
        {
            if (string.IsNullOrEmpty(options.Url))
            {
                return ValidateOptionsResult.Fail($"{nameof(options.Url)} configuration parameter for the Authorization Service is required");
            }

            return ValidateOptionsResult.Success;
        }
    }
}
