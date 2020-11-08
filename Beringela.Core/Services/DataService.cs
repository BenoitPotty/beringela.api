using System;
using System.Collections.Generic;
using Beringela.Core.Entities;
using Beringela.Core.Repositories;
using Microsoft.AspNetCore.JsonPatch;

namespace Beringela.Core.Services
{
    public class DataService<T> : IDataService<T> where T : class, IDataEntity
    {
        protected IDataRepository<T> Repository { get;}

        public DataService(IDataRepository<T> repository)
        {
            Repository = repository;
        }

        //TODO pagination => paginated result structure
        //TODO mobile endpoints
        //TODO Entity validation
        public IEnumerable<T> TextualSearch(string search, SortOptions sortOptions, PagingOptions pagingOptions)
        {
            return Repository.Where(PredicateBuilder.TextualSearch<T>(search), sortOptions, pagingOptions);
        }

        public IEnumerable<T> Where(Func<T, bool> predicate, SortOptions sortOptions, PagingOptions pagingOptions)
        {
            return Repository.Where(predicate, sortOptions, pagingOptions);
        }

        public T Get(Guid id)
        {
            return Repository.Get(id);
        }

        public T Add(T entity)
        {
            
            return Repository.Add(entity);
        }

        public T Delete(Guid id)
        {
            return Repository.Delete(id);
        }

        public T Patch(Guid id, JsonPatchDocument<T> patchData)
        {
            var entity = Repository.Get(id);
            patchData.ApplyTo(entity);
            return Repository.Update(entity);
        }
    }
}
