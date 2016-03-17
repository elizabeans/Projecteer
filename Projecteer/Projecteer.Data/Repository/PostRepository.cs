using Projecteer.Core.Domain;
using Projecteer.Core.Repository;
using Projecteer.Data.Infrastructure;

namespace Projecteer.Data.Repository
{
    public class PostRepository : Repository<Post>, IPostRepository
    {
        public PostRepository(IDatabaseFactory databaseFactory) : base(databaseFactory)
        {

        }
    }
}
