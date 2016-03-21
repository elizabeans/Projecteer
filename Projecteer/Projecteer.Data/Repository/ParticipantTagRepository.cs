using Projecteer.Core.Domain;
using Projecteer.Core.Repository;
using Projecteer.Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projecteer.Data.Repository
{
    public class ParticipantTagRepository : Repository<ParticipantTag>, IParticipantTagRepository
    {
        public ParticipantTagRepository(IDatabaseFactory databaseFactory) : base(databaseFactory)
        {

        }
    }
}
