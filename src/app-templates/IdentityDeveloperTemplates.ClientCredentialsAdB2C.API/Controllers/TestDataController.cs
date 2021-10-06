using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace IdentityDeveloperTemplates.ClientCredentialsAdB2C.API.Controllers
{
    [Authorize(Policy = "OnlyAuthorizedAccess")]
    [ApiController]
    [Route("[controller]")]
    public class TestDataController : ControllerBase
    {
        private readonly ILogger<TestDataController> _logger;

        public TestDataController(ILogger<TestDataController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Operation authorized");
        }
    }
}
