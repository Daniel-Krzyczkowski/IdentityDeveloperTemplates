using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Security.Claims;

namespace IdentityDeveloperTemplates.AzureADB2C.API.Controllers
{
    [Authorize]
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
            var userId = new Guid(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
            string owner = User.FindFirst(c => c.Type == "name")?.Value;
            return Ok($"User id: {userId} and owner: {owner}");
        }
    }
}
