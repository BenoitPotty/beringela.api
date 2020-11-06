using System.Collections.Generic;

namespace Beringela.Core.Services
{
    // TODO understand covariant
    public interface IDataService<out T>
    {
        IEnumerable<T> Select();
    }
}
