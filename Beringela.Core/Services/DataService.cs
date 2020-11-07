using System;
using System.Collections.Generic;
using Beringela.Core.Entities;
using Beringela.Core.Repositories;

namespace Beringela.Core.Services
{
    public class DataService<T> : IDataService<T> where T : IDataEntity
    {
        protected IDataRepository<T> Repository { get;}

        public DataService(IDataRepository<T> repository)
        {
            Repository = repository;
        }
       
        //TODO pass sort / pagination / mobile
        public IEnumerable<T> Select(string search)
        {
            return Repository.Select(PredicateBuilder.TextualSearch<T>(search));
        }
    }
}
