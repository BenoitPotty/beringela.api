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

        public IEnumerable<T> Where(Func<T, bool> predicate = null, SortOptions sortOptions = null, PagingOptions pagingOptions = null)
        {
            return _dbContext.Set<T>()
                .Where(predicate ?? AllPredicate)
                .AsQueryable()
                .Sort(sortOptions)
                .Paginate(pagingOptions);
        }

        public T Get(Guid id)
        {
            try
            {
                return _dbContext.Set<T>().First(entity => entity.Id.Equals(id));
            }
            catch (InvalidOperationException)
            {
                throw new EntityNotFoundException<T>(id);
            }
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

        public T Update(T entity)
        {
           var updatedEntity =  _dbContext.Update(entity).Entity;
           _dbContext.SaveChanges();
           return updatedEntity;
        }
    }
}
