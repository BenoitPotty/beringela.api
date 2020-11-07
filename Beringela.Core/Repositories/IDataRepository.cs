﻿using System;
using System.Collections.Generic;
using Beringela.Core.Entities;

namespace Beringela.Core.Repositories
{
    public interface IDataRepository<out T> where T : IDataEntity
    {
        IEnumerable<T> Select(Func<T, bool> predicate = null);
        T Get(Guid id);
    }
}
