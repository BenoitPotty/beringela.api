using System.Collections.Generic;
using Beringela.Core.Repositories;

namespace Beringela.Core.Services
{
    public class DataService<T> : IDataService<T> where T : new()
    {
        protected IDataRepository<T> Repository { get;}

        public DataService(IDataRepository<T> repository)
        {
            Repository = repository;
        }
        //TODO pass predicate / sort / pagination / mobile
        public IEnumerable<T> Select()
        {
            return Repository.Select();
        }
    }
}
