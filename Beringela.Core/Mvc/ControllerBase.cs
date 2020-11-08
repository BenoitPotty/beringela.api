using System;
using System.Collections.Generic;
using Beringela.Core.Entities;
using Beringela.Core.Repositories;
using Beringela.Core.Services;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Beringela.Core.Mvc
{
    [ApiController]
    [Route("[controller]")]
    public class ControllerBase<T> : ControllerBase where T : class, IDataEntity
    {
        protected IDataService<T> Service { get; }
        protected ILogger<ControllerBase<T>> Logger { get; }

        public ControllerBase(ILogger<ControllerBase<T>> logger, IDataService<T> service)
        {
            Service = service;
            Logger = logger;
        }

        [HttpGet]
        public IEnumerable<T> Get([FromQuery]string search, [FromQuery]string sort = null, [FromQuery]bool descending = false, [FromQuery] uint page = 0, [FromQuery] uint pageSize = 0)
        {
            return Service.TextualSearch(search, new SortOptions(sort, descending), new PagingOptions(page, pageSize));
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

        [HttpDelete("{id}")]
        public T Post(Guid id)
        {
            return Service.Delete(id);
        }

        [HttpPatch("{id}")]
        public T Patch(Guid id, [FromBody] JsonPatchDocument<T> patchData)
        {
            return Service.Patch(id, patchData);
        }
    }
}
