using System;
using System.Collections.Generic;
using Beringela.Core.Entities;

namespace Beringela.Core.Services
{
    public interface IDataService<T> where T : IDataEntity
    {
        IEnumerable<T> TextualSearch(string search);
        IEnumerable<T> Where(Func<T, bool> predicate);
        T Get(Guid id);
        T Add(T entity);
        T Delete(Guid id);
    }
}
