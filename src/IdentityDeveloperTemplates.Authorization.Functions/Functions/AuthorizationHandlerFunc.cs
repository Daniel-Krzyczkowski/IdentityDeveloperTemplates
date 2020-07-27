using IdentityDeveloperTemplates.Authorization.Functions.Queries.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.IO;
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

        [FunctionName("get-user-authorization-groups-func")]
        public async Task<IActionResult> GetUserAuthorizationGroupsAsync(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation($"{nameof(GetUserAuthorizationGroupsAsync)} HTTP trigger function received a request");

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            var userId = data.userId;

            if (userId == null)
            {
                log.LogInformation("UserId parameter is required");
                return new BadRequestResult();
            }

            else
            {
                var userAuthorizationGroups = await _authorizationQueries
                                                    .GetAuthorizationGroupsForUserAsync(Guid.Parse(userId.ToString()));

                log.LogInformation("Successfully retrieved authorization groups for specific user");

                return new OkObjectResult(userAuthorizationGroups);
            }
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
    }
}
