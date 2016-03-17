using Projecteer.Core.Domain;
using Projecteer.Core.Repository;
using Projecteer.Data.Infrastructure;

namespace Projecteer.Data.Repository
{
    public class UserRoleRepository : Repository<UserRole>, IUserRoleRepository
    {
        public UserRoleRepository(IDatabaseFactory databaseFactory): base(databaseFactory)
        {

        }
    }
}
