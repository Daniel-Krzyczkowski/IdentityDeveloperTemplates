using IdentityDeveloperTemplates.AzureAD.Authz.API.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace IdentityDeveloperTemplates.AzureAD.Authz.API.Controllers
{
    [Authorize(Roles = "DirectManager")]
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            string userDisplayName = HttpContext.User
                                             .FindFirst(c => c.Type == "name")
                                             .Value;
            var apiResponse = new ApiResponse
            {
                GreetingFromApi = $"Hello {userDisplayName}!"
            };

            return Ok(apiResponse);
        }
    }
}
