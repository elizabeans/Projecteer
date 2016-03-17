using Projecteer.Core.Domain;
using Projecteer.Core.Repository;
using Projecteer.Data.Infrastructure;

namespace Projecteer.Data.Repository
{
    public class ProjecteerUserRepository : Repository<ProjecteerUser>, IProjecteerUserRepository
    {
        public ProjecteerUserRepository(IDatabaseFactory databaseFactory) : base(databaseFactory)
        {

        }
    }
}
