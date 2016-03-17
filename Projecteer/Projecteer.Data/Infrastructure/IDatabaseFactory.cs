using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projecteer.Data.Infrastructure
{
    public interface IDatabaseFactory : IDisposable
    {
        ProjecteerDataContext GetDataContext();
    }
}
