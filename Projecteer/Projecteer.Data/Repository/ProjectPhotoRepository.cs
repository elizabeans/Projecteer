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
    public class ProjectPhotoRepository : Repository<ProjectPhoto>, IProjectPhotoRepository
    {
        public ProjectPhotoRepository(IDatabaseFactory databaseFactory) : base(databaseFactory)
        {

        }
    }
}
