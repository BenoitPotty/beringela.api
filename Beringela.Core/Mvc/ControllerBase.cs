using System;
using System.Collections.Generic;
using Beringela.Core.Entities;
using Beringela.Core.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Beringela.Core.Mvc
{
    public class ControllerBase<T> : ControllerBase where T : IDataEntity
    {
        protected IDataService<T> Service { get; }
        protected ILogger<ControllerBase<T>> Logger { get; }

        public ControllerBase(ILogger<ControllerBase<T>> logger, IDataService<T> service)
        {
            Service = service;
            Logger = logger;
        }

        // TODO : Move Basic Methods here
        [HttpGet]
        public IEnumerable<T> Get([FromQuery]string search)
        {
            return Service.TextualSearch(search);
        }

        [HttpGet("{id}")]
        public T Get(Guid id)
        {
            return Service.Get(id);
        }

        [HttpPost]
        public T Post(T entity)
        {
            return Service.Add(entity);
        }
    }
}
