using Projecteer.Core.Domain;
using Projecteer.Core.Repository;
using Projecteer.Data.Infrastructure;

namespace Projecteer.Data.Repository
{
    public class TagRepository : Repository<Tag>, ITagRepository
    {
        public TagRepository(IDatabaseFactory databaseFactory) : base(databaseFactory)
        {

        }
    }
}
