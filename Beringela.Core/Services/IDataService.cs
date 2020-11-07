using System;
using System.Collections.Generic;
using Beringela.Core.Entities;

namespace Beringela.Core.Services
{
    // TODO understand covariant
    public interface IDataService<out T> where T : IDataEntity
    {
        IEnumerable<T> Select(string search);
        T Get(Guid id);
    }
}
