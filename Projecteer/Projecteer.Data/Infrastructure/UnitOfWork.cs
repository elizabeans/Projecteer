using Projecteer.Core.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projecteer.Data.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDatabaseFactory _databaseFactory;
        private ProjecteerDataContext _dataContext;

        protected ProjecteerDataContext DataContext
        {
            get
            {
                return _dataContext ?? (_dataContext = _databaseFactory.GetDataContext());
            }
        }

        public void Commit()
        {
            DataContext.SaveChanges();
        }

        public UnitOfWork(IDatabaseFactory databaseFactory)
        {
            _databaseFactory = databaseFactory;
        }
    }
}
