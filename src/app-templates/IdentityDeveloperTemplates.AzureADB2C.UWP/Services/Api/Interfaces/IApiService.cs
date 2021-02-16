using IdentityDeveloperTemplates.AzureADB2C.UWP.Services.Authentication;
using System.Threading.Tasks;

namespace IdentityDeveloperTemplates.AzureADB2C.UWP.Services.Api.Interfaces
{
    internal interface IApiService
    {
        Task<ApiResponse> GetGreetingFromApiAsync(AuthenticationData authenticationData);
    }
}
