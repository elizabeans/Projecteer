using Projecteer.Core.Domain;
using Projecteer.Core.Repository;
using Projecteer.Data.Infrastructure;

namespace Projecteer.Data.Repository
{
    public class ProjectTagRepository : Repository<ProjectTag>, IProjectTagRepository
    {
        public ProjectTagRepository(IDatabaseFactory databaseFactory) : base(databaseFactory)
        {

        }
    }
}
