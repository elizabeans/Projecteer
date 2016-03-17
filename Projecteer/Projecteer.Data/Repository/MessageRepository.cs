using Projecteer.Core.Domain;
using Projecteer.Core.Repository;
using Projecteer.Data.Infrastructure;

namespace Projecteer.Data.Repository
{
    public class MessageRepository : Repository<Message>, IMessageRepository
    {
        public MessageRepository(IDatabaseFactory databaseFactory) : base(databaseFactory)
        {

        }
    }
}
