﻿using System;
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
        public IEnumerable<T> TextualSearch(string search)
        {
            return Repository.Select(PredicateBuilder.TextualSearch<T>(search));
        }

        public IEnumerable<T> Where(Func<T, bool> predicate)
        {
            return Repository.Select(predicate);
        }

        public T Get(Guid id)
        {
            return Repository.Get(id);
        }
    }
}
