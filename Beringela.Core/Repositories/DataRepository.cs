using System.Collections.Generic;
using System.Linq;

namespace Beringela.Core.Repositories
{
    public class DataRepository<T> : IDataRepository<T> where T: new()
    {
        public IEnumerable<T> Select()
        {
            return Enumerable.Range(1, 5).Select(index => new T())
                .ToArray();
        }
    }
}
