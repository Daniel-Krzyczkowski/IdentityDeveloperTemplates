using IdentityDeveloperTemplates.Authorization.Functions.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IdentityDeveloperTemplates.Authorization.Functions.Queries.Interfaces
{
    public interface IAuthorizationQueries
    {
        Task<IEnumerable<UserAuthorizationGroup>> GetAuthorizationGroupsForUserAsync(Guid userId);
        Task<IEnumerable<AuthorizationGroup>> GetAuthorizationGroupsAsync();
    }
}
