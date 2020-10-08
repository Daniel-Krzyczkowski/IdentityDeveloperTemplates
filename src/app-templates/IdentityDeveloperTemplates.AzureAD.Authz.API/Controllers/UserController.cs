using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Identity.Client;
using Microsoft.Identity.Web;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Threading.Tasks;

namespace IdentityDeveloperTemplates.AzureAD.Authz.API.Controllers
{
    [Authorize(Policy = "Employee")]
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly ITokenAcquisition _tokenAcquisition;

        public UserController(ILogger<UserController> logger, ITokenAcquisition tokenAcquisition)
        {
            _logger = logger;
            _tokenAcquisition = tokenAcquisition;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var userId = new Guid(HttpContext.User
                                             .FindFirst(c => c.Type == "http://schemas.microsoft.com/identity/claims/objectidentifier")
                                             .Value);

            string owner = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            string ownerName = string.Empty;

            try
            {
                ownerName = await CallGraphApiOnBehalfOfUser();
                return Ok($"User id: {userId} and name: {ownerName}");
            }
            catch (MsalException ex)
            {
                HttpContext.Response.ContentType = "text/plain";
                HttpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                await HttpContext.Response.WriteAsync("An authentication error occurred while acquiring a token for downstream API\n" + ex.ErrorCode + "\n" + ex.Message);
            }
            catch (Exception ex)
            {
                HttpContext.Response.ContentType = "text/plain";
                HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                await HttpContext.Response.WriteAsync("An error occurred while calling the downstream API\n" + ex.Message);
            }

            return BadRequest();
        }


        public async Task<string> CallGraphApiOnBehalfOfUser()
        {
            string[] scopes = { "user.read" };

            // we use MSAL.NET to get a token to call the API On Behalf Of the current user
            try
            {
                string accessToken = await _tokenAcquisition.GetAccessTokenForUserAsync(scopes);
                dynamic me = await CallGraphApiOnBehalfOfUser(accessToken);
                return me.displayName;
            }
            catch (MsalUiRequiredException ex)
            {
                await _tokenAcquisition.ReplyForbiddenWithWwwAuthenticateHeaderAsync(scopes, ex);
                return string.Empty;
            }
        }

        private static async Task<dynamic> CallGraphApiOnBehalfOfUser(string accessToken)
        {
            // Call the Graph API and retrieve the user's profile.
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            HttpResponseMessage response = await client.GetAsync("https://graph.microsoft.com/v1.0/me");
            string content = await response.Content.ReadAsStringAsync();
            if (response.StatusCode == HttpStatusCode.OK)
            {
                dynamic me = JsonConvert.DeserializeObject(content);
                return me;
            }

            throw new Exception(content);
        }
    }
}
