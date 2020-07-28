using IdentityDeveloperTemplates.AzureADB2C.WebApp.Authorization.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IdentityDeveloperTemplates.AzureADB2C.WebApp.Authorization.Services.Interfaces
{
    public interface IAuthorizationGroupService
    {
        Task<IEnumerable<AuthorizationGroup>> GetAuthorizationGroups();
    }
}
