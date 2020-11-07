using System;
using System.Collections.Generic;
using System.Linq;
using Beringela.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Beringela.Core.Repositories
{
    public class DataRepository<T> : IDataRepository<T> where T: class, IDataEntity
    {
        private static readonly Func<T, bool> AllPredicate = entity => true;
        private readonly DbContext _dbContext;

        public DataRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<T> Where(Func<T, bool> predicate = null)
        {
            return _dbContext.Set<T>().Where(predicate ?? AllPredicate);
        }

        public T Get(Guid id)
        {
            return _dbContext.Set<T>().FirstOrDefault(entity => entity.Id.Equals(id));
        }
    }
}
