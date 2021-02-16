using System.Threading.Tasks;

namespace IdentityDeveloperTemplates.AzureAD.UWP.Authz.Services.Authentication.Interfaces
{
    public interface IAuthenticationService
    {
        Task<AuthenticationData> Authenticate();
        Task SignOut();
    }
}
