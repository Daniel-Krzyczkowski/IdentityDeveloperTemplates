using IdentityDeveloperTemplates.AzureADB2C.WebApp.Services.Identity.Model;
using System.Threading.Tasks;

namespace IdentityDeveloperTemplates.AzureADB2C.WebApp.Services.Identity.Interfaces
{
    public interface IAzureAdB2CGraphClientUserService
    {
        Task<AzureAdB2CUser> GetUserByObjectId(string objectId);
        Task<byte[]> GetUserPictureByObjectId(string objectId);
    }
}
