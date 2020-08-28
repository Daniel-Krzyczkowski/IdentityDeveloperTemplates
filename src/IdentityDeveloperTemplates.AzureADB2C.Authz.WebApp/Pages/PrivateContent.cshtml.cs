using IdentityDeveloperTemplates.AzureADB2C.WebApp.Services.Identity.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace IdentityDeveloperTemplates.AzureADB2C.WebApp.Pages
{
    [Authorize(Policy = "Employee")]
    [Authorize]
    public class PrivateContentModel : PageModel
    {
        private readonly IAzureAdB2CGraphClientUserService _azureAdB2CGraphClientUserService;

        private Guid _userId;
        public byte[] UserPhoto { get; private set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }

        public PrivateContentModel(IAzureAdB2CGraphClientUserService azureAdB2CGraphClientUserService)
        {
            _azureAdB2CGraphClientUserService = azureAdB2CGraphClientUserService;
        }

        public async Task OnGet()
        {
            _userId = new Guid(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
            await CallGraphApi(_userId.ToString());
        }

        private async Task CallGraphApi(string userId)
        {
            var user = await _azureAdB2CGraphClientUserService.GetUserByObjectId(userId);
            UserFirstName = user.GivenName;
            UserLastName = user.Surname;
            UserPhoto = await _azureAdB2CGraphClientUserService.GetUserPictureByObjectId(userId);
        }
    }
}