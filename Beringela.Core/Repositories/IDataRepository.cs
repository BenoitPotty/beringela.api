using System.Collections.Generic;

namespace Beringela.Core.Repositories
{
    public interface IDataRepository<out T>
    {
        IEnumerable<T> Select();
    }
}
