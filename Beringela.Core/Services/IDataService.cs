using System;
using System.Collections.Generic;
using Beringela.Core.Entities;
using Beringela.Core.Repositories;
using Microsoft.AspNetCore.JsonPatch;

namespace Beringela.Core.Services
{
    public interface IDataService<T> where T : class, IDataEntity
    {
        IEnumerable<T> TextualSearch(string search, SortOptions sortOptions);
        IEnumerable<T> Where(Func<T, bool> predicate);
        T Get(Guid id);
        T Add(T entity);
        T Delete(Guid id);
        T Patch(Guid id, JsonPatchDocument<T> patchData);
    }
}
