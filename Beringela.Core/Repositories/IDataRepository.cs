﻿using System;
using System.Collections.Generic;
using Beringela.Core.Entities;

namespace Beringela.Core.Repositories
{
    public interface IDataRepository<T> where T : class, IDataEntity
    {
        IEnumerable<T> Where(Func<T, bool> predicate = null, SortOptions sortOptions = null, PagingOptions pagingOptions = null);
        int Count(Func<T, bool> predicate = null);
        T Get(Guid id);
        T Add(T entity);
        T Delete(Guid id);
        T Update(T entity);
    }
}
