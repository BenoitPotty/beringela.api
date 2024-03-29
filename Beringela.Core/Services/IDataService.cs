﻿using System;
using System.Collections.Generic;
using Beringela.Core.Entities;
using Beringela.Core.Repositories;
using Microsoft.AspNetCore.JsonPatch;

namespace Beringela.Core.Services
{
    public interface IDataService<T> where T : class, IDataEntity
    {
        IEnumerable<T> TextualSearch(string search, SortOptions sortOptions, PagingOptions pagingOptions);
        uint TextualCount(string search);
        IEnumerable<T> Where(Func<T, bool> predicate, SortOptions sortOptions, PagingOptions pagingOptions);
        uint Count(Func<T, bool> predicate = null);
        T Get(Guid id);
        T Add(T entity);
        T Delete(Guid id);
        T Patch(Guid id, JsonPatchDocument<T> patchData);
    }
}
