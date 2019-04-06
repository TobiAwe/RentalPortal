using System.Security.Claims;
using System.Threading.Tasks;

namespace RentalPortal.Identity.Services
{
    public interface IUserService
    {
        Task<string> GenerateEncodedToken(string userName, ClaimsIdentity identity);
        ClaimsIdentity GenerateClaimsIdentity(string userName, string id);
    }
}
