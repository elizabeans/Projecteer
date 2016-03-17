using Microsoft.AspNet.Identity;
using Projecteer.Core.Domain;
using Projecteer.Core.Infrastructure;
using Projecteer.Core.Models;
using System.Threading.Tasks;

namespace Projecteer.Data.Infrastructure
{
    public class AuthorizationRepository : IAuthorizationRepository
    {
        private readonly IUserStore<ProjecteerUser> _userStore;
        private readonly IDatabaseFactory _databaseFactory;
        private readonly UserManager<ProjecteerUser> _userManager;

        private ProjecteerDataContext db;
        protected ProjecteerDataContext Db => db ?? (db = _databaseFactory.GetDataContext());

        public AuthorizationRepository(IDatabaseFactory databaseFactory, IUserStore<ProjecteerUser> userStore)
        {
            _userStore = userStore;
            _databaseFactory = databaseFactory;
            _userManager = new UserManager<ProjecteerUser>(userStore);
        }

        public async Task<IdentityResult> RegisterUser(RegistrationModel model)
        {
            // create a user
            var projecteerUser = new ProjecteerUser
            {
                UserName = model.UserName,
                Email = model.EmailAddress,
                FirstName = model.FirstName,
                LastName = model.LastName
            };

            var result = await _userManager.CreateAsync(projecteerUser, model.Password);

            await _userManager.AddToRoleAsync(projecteerUser.Id, "User");

            return result;
        }

        public async Task<IdentityResult> RegisterAdmin(RegistrationModel model)
        {
            var projecteerUser = new ProjecteerUser
            {
                UserName = model.UserName,
                Email = model.EmailAddress
            };

            var result = await _userManager.CreateAsync(projecteerUser, model.Password);

            await _userManager.AddToRoleAsync(projecteerUser.Id, "Admin");

            return result;
        }

        public async Task<ProjecteerUser> FindUser (string username, string password)
        {
            return await _userManager.FindAsync(username, password);
        }
    }
}
