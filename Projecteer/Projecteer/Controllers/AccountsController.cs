using Projecteer.Core.Infrastructure;
using Projecteer.Core.Models;
using System.Web.Http;
using System.Threading.Tasks;

namespace Projecteer.API.Controllers
{
    public class AccountsController : ApiController
    {
        private IAuthorizationRepository _repo;

        public AccountsController(IAuthorizationRepository repo)
        {
            _repo = repo;
        }

        [AllowAnonymous]
        [Route("api/accounts/register")]
        public async Task<IHttpActionResult> RegisterUser(RegistrationModel registration)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _repo.RegisterUser(registration);

            if(result.Succeeded)
            {
                return Ok();
            }
            else
            {
                return BadRequest("Registration form was invalid.");
            }
        }

        [AllowAnonymous] // TODO: Change possibly in future 
        [Route("api/accounts/register/admin")]
        public async Task<IHttpActionResult> RegisterAdmin(RegistrationModel registration)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _repo.RegisterAdmin(registration);

            if(result.Succeeded)
            {
                return Ok();
            }
            else
            {
                return BadRequest("Registration form was invalid.");
            }
        }
    }
}
