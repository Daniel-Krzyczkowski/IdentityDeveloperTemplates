using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Graph;
using Microsoft.Graph.Auth;
using Microsoft.Identity.Client;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace IdentityDeveloperTemplates.AzureADB2C.WebApp.Pages
{
    [Authorize]
    public class PrivateContentModel : PageModel
    {
        public Guid UserId { get; set; }

        public async Task OnGet()
        {
            UserId = new Guid(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
            await CallGraph();
        }

        private async Task CallGraph()
        {
            // Initialize the client credential auth provider
            IConfidentialClientApplication confidentialClientApplication = ConfidentialClientApplicationBuilder
                .Create("d32de3ae-07ba-4172-a9d8-ed60f9ddeb62")
                .WithTenantId("f07bf31b-c0b6-4878-9302-93a41050358c")
                .WithClientSecret("4x2mhxz80Ig~lyD_49hK_pQ_I_b-uy0E_N")
                .Build();
            ClientCredentialProvider authProvider = new ClientCredentialProvider(confidentialClientApplication);

            // Set up the Microsoft Graph service client with client credentials
            GraphServiceClient graphClient = new GraphServiceClient(authProvider);
            var user = await graphClient.Users["d34f52a6-d2ea-4911-9263-85c9a4968c7d"]
                                        .Request()
                                        .GetAsync();
        }
    }
}