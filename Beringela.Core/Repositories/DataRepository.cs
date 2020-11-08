using System;
using System.Collections.Generic;
using System.Linq;
using Beringela.Core.Entities;
using Beringela.Core.Exceptions;
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

        public T Add(T entity)
        {
            var savedEntity =_dbContext.Set<T>().Add(entity).Entity;
            _dbContext.SaveChanges();
            return savedEntity;
        }

        public T Delete(Guid id)
        {
            var deletedEntity = Get(id);
            if (deletedEntity == null) throw new EntityNotFoundException<T>(id);
            _dbContext.Remove(deletedEntity);
            _dbContext.SaveChanges();
            return deletedEntity;
        }
    }
}
