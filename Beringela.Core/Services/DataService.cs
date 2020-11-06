using System.Collections.Generic;
using System.Linq;

namespace Beringela.Core.Services
{
    public class DataService<T> : IDataService<T> where T : new()
    {
        //TODO pass predicate / sort / pagination / mobile

        public IEnumerable<T> Select()
        {
            return Enumerable.Range(1, 5).Select(index => new T())
                .ToArray();
        }
    }
}
