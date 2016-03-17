using Projecteer.Core.Domain;
using Projecteer.Core.Repository;
using Projecteer.Data.Infrastructure;

namespace Projecteer.Data.Repository
{
    public class ParticipationRepository : Repository<Participation>, IParticipationRepository
    {
        public ParticipationRepository(IDatabaseFactory databaseFactory) : base(databaseFactory)
        {

        }
    }
}
