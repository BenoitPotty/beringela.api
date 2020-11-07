using System;
using System.Collections.Generic;
using Beringela.Core.Entities;

namespace Beringela.Core.Repositories
{
    public interface IDataRepository<T> where T : IDataEntity
    {
        IEnumerable<T> Where(Func<T, bool> predicate = null);
        T Get(Guid id);
        T Add(T entity);
    }
}
