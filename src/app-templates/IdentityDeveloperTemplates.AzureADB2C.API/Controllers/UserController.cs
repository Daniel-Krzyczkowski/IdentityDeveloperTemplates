using IdentityDeveloperTemplates.AzureADB2C.API.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace IdentityDeveloperTemplates.AzureADB2C.API.Controllers
{
    [Authorize(Policy = "Access_Identity_API_As_User")]
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
        public IActionResult GetGreeting()
        {
            string userDisplayName = User.FindFirst(c => c.Type == "displayName")?.Value;
            var apiResponse = new ApiResponse
            {
                GreetingFromApi = $"Hello {userDisplayName}!"
            };
            return Ok(apiResponse);
        }
    }
}
