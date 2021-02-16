using IdentityDeveloperTemplates.AzureAD.API.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Graph;
using Microsoft.Identity.Client;
using Microsoft.Identity.Web;
using System;
using System.Net;
using System.Threading.Tasks;

namespace IdentityDeveloperTemplates.AzureAD.API.Controllers
{
    [Authorize(Policy = "Access_Identity_API_As_User")]
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly ITokenAcquisition _tokenAcquisition;
        private readonly GraphServiceClient _graphServiceClient;
        private readonly IOptions<MicrosoftGraphOptions> _graphOptions;

        public UserController(ILogger<UserController> logger,
                              ITokenAcquisition tokenAcquisition,
                              GraphServiceClient graphServiceClient,
                              IOptions<MicrosoftGraphOptions> graphOptions)
        {
            _logger = logger;
            _tokenAcquisition = tokenAcquisition;
            _graphServiceClient = graphServiceClient;
            _graphOptions = graphOptions;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                User user = await _graphServiceClient.Me.Request().GetAsync();
                var userDisplayName = user.DisplayName;

                var apiResponse = new ApiResponse
                {
                    GreetingFromApi = $"Hello {userDisplayName}!"
                };

                return Ok(apiResponse);
            }
            catch (MsalException ex)
            {
                HttpContext.Response.ContentType = "text/plain";
                HttpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                await HttpContext.Response.WriteAsync("An authentication error occurred while acquiring a token for downstream API\n" + ex.ErrorCode + "\n" + ex.Message);
            }
            catch (Exception ex)
            {
                if (ex.InnerException is MicrosoftIdentityWebChallengeUserException challengeException)
                {
                    await _tokenAcquisition.ReplyForbiddenWithWwwAuthenticateHeaderAsync(_graphOptions.Value.Scopes.Split(' '),
                                                                                         challengeException.MsalUiRequiredException);
                }
                else
                {
                    HttpContext.Response.ContentType = "text/plain";
                    HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    await HttpContext.Response.WriteAsync("An error occurred while calling the downstream API\n" + ex.Message);
                }
            }

            return BadRequest();
        }
    }
}
