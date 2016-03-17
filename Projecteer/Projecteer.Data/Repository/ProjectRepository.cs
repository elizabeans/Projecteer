using Projecteer.Core.Domain;
using Projecteer.Core.Repository;
using Projecteer.Data.Infrastructure;

namespace Projecteer.Data.Repository
{
    public class ProjectRepository : Repository<Project>, IProjectRepository
    {
        public ProjectRepository(IDatabaseFactory databaseFactory) : base(databaseFactory)
        {

        }
    }
}
