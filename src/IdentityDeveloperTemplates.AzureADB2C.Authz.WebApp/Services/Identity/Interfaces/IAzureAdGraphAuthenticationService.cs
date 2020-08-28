using System.Net.Http;
using System.Threading.Tasks;

namespace IdentityDeveloperTemplates.AzureADB2C.Authz.WebApp.Services.Identity.Interfaces
{
    public interface IAzureAdGraphAuthenticationService
    {
        Task AuthenticateRequestAsync(HttpRequestMessage request);
    }
}
