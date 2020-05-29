using System.Threading.Tasks;

namespace IdentityDeveloperTemplates.AzureAD.UWP.Services.Authentication.Interfaces
{
    public interface IAuthenticationService
    {
        Task<AuthenticationData> Authenticate();
    }
}
