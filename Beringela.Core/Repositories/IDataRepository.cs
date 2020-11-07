using System;
using System.Collections.Generic;

namespace Beringela.Core.Repositories
{
    public interface IDataRepository<out T>
    {
        IEnumerable<T> Select(Func<T, bool> predicate = null);
    }
}
