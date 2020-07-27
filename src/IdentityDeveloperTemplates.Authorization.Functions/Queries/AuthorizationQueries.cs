using Dapper;
using IdentityDeveloperTemplates.Authorization.Functions.Configuration.Interfaces;
using IdentityDeveloperTemplates.Authorization.Functions.Model;
using IdentityDeveloperTemplates.Authorization.Functions.Queries.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace IdentityDeveloperTemplates.Authorization.Functions.Queries
{
    internal class AuthorizationQueries : IAuthorizationQueries
    {
        private readonly IAzureSqlDatabaseConfiguration _azureSqlDatabaseConfiguration;

        public AuthorizationQueries(IAzureSqlDatabaseConfiguration azureSqlDatabaseConfiguration)
        {
            _azureSqlDatabaseConfiguration = azureSqlDatabaseConfiguration
                                             ?? throw new ArgumentNullException(nameof(azureSqlDatabaseConfiguration));
        }

        public async Task<IEnumerable<UserAuthorizationGroup>> GetAuthorizationGroupsForUserAsync(Guid userId)
        {
            using (var connection = new SqlConnection(_azureSqlDatabaseConfiguration.ConnectionString))
            {
                connection.Open();

                var authorizationGroups = await connection.QueryAsync<UserAuthorizationGroup>(
                   @"select Id, UserId, GroupId FROM dbo.UserAuthorizationGroups
                     WHERE UserId=@userID", new { userId });

                if (authorizationGroups.AsList().Count == 0)
                {
                    throw new KeyNotFoundException();
                }

                else
                {
                    return authorizationGroups;
                }
            }
        }

        public async Task<IEnumerable<AuthorizationGroup>> GetAuthorizationGroupsAsync()
        {
            using (var connection = new SqlConnection(_azureSqlDatabaseConfiguration.ConnectionString))
            {
                connection.Open();

                var authorizationGroups = await connection.QueryAsync<AuthorizationGroup>(
                   @"select Id, GroupId, GroupName FROM dbo.AuthorizationGroups");

                if (authorizationGroups.AsList().Count == 0)
                {
                    throw new KeyNotFoundException();
                }

                else
                {
                    return authorizationGroups;
                }
            }
        }
    }
}
