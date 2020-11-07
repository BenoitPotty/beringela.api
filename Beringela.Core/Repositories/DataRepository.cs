using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Beringela.Core.Repositories
{
    public class DataRepository<T> : IDataRepository<T> where T: class, new()
    {
        private readonly DbContext _dbContext;

        public DataRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<T> Select()
        {
            return _dbContext.Set<T>().ToList();
        }
    }
}
