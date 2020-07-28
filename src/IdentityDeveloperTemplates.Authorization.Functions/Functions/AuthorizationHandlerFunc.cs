using IdentityDeveloperTemplates.Authorization.Functions.DTOs;
using IdentityDeveloperTemplates.Authorization.Functions.Queries.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityDeveloperTemplates.Authorization.Functions
{
    public class AuthorizationHandlerFunc
    {
        private readonly IAuthorizationQueries _authorizationQueries;

        public AuthorizationHandlerFunc(IAuthorizationQueries authorizationQueries)
        {
            _authorizationQueries = authorizationQueries;
        }

        [FunctionName("get-user-authorization-groups-identifiers-func")]
        public async Task<IActionResult> GetUserAuthorizationGroupsIdentifiersAsync(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            return await GetUserGroupsDataAsync(req, false, log);
        }

        [FunctionName("get-user-authorization-groups-func")]
        public async Task<IActionResult> GetUserAuthorizationGroupsAsync(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            return await GetUserGroupsDataAsync(req, true, log);
        }

        [FunctionName("get-authorization-groups-func")]
        public async Task<IActionResult> GetAuthorizationGroupsAsync(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation($"{nameof(GetAuthorizationGroupsAsync)} HTTP trigger function received a request");

            var authorizationGroups = await _authorizationQueries
                                                .GetAuthorizationGroupsAsync();

            log.LogInformation("Successfully retrieved authorization groups");

            return new OkObjectResult(authorizationGroups);
        }

        private async Task<IActionResult> GetUserGroupsDataAsync(HttpRequest req, bool includeGroupNames, ILogger log)
        {
            log.LogInformation($"{nameof(GetUserAuthorizationGroupsAsync)} HTTP trigger function received a request");


            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            var userId = data.userId;
            string userIdAsString = userId.ToString();

            if (userId == null)
            {
                log.LogInformation("UserId parameter is required");
                return new BadRequestResult();
            }

            else
            {
                var userAuthorizationGroups = await _authorizationQueries
                                                    .GetAuthorizationGroupsForUserAsync(Guid.Parse(userIdAsString));

                log.LogInformation("Successfully retrieved authorization groups for specific user");

                if (includeGroupNames == true)
                {
                    return new OkObjectResult(new UserAuthorizationGroupsDto
                    {
                        AuthorizationGroups = userAuthorizationGroups
                    });
                }

                else
                {
                    return new OkObjectResult(new UserAuthorizationGroupsIdentifiersDto
                    {
                        AuthorizationGroups = userAuthorizationGroups.Select(x => x.GroupId)
                    });
                }
            }
        }
    }
}
