using IdentityDeveloperTemplates.AzureAD.UWP.Services.Authentication;
using System.Threading.Tasks;

namespace IdentityDeveloperTemplates.AzureAD.UWP.Services.Api.Interfaces
{
    internal interface IApiService
    {
        Task<ApiResponse> GetGreetingFromApiAsync(AuthenticationData authenticationData);
    }
}
