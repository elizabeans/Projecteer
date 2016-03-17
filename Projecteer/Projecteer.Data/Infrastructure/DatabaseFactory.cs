using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projecteer.Core.Infrastructure;

namespace Projecteer.Data.Infrastructure
{
    public class DatabaseFactory : Disposable, IDatabaseFactory
    {
        private readonly ProjecteerDataContext _dataContext;

        public ProjecteerDataContext GetDataContext()
        {
            return _dataContext ?? new ProjecteerDataContext();
        }

        public DatabaseFactory()
        {
            _dataContext = new ProjecteerDataContext();
        }

        protected override void DisposeCore()
        {
            if (_dataContext != null) _dataContext.Dispose();
        }
    }
}
