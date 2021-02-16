using IdentityDeveloperTemplates.AzureAD.UWP.Authz.Services.Authentication;
using System.Threading.Tasks;

namespace IdentityDeveloperTemplates.AzureAD.UWP.Authz.Services.Api.Interfaces
{
    internal interface IApiService
    {
        Task<ApiResponse> GetGreetingFromApiAsync(AuthenticationData authenticationData);
    }
}
