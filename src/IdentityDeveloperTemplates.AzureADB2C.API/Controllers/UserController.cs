using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace IdentityDeveloperTemplates.AzureADB2C.API.Controllers
{
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
            return Ok();
        }
    }
}
