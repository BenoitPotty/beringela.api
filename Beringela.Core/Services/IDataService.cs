using System;
using System.Collections.Generic;
using Beringela.Core.Entities;

namespace Beringela.Core.Services
{
    // TODO understand covariant
    public interface IDataService<out T> where T : IDataEntity
    {
        IEnumerable<T> TextualSearch(string search);
        IEnumerable<T> Where(Func<T, bool> predicate);
        T Get(Guid id);
    }
}
