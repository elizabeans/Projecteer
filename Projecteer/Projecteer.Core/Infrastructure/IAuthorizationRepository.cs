using Microsoft.AspNet.Identity;
using Projecteer.Core.Domain;
using Projecteer.Core.Models;
using System.Threading.Tasks;

namespace Projecteer.Core.Infrastructure
{
    public interface IAuthorizationRepository
    {
        Task<ProjecteerUser> FindUser(string username, string password);
        Task<IdentityResult> RegisterAdmin(RegistrationModel model);
        Task<IdentityResult> RegisterUser(RegistrationModel model);
    }
}
