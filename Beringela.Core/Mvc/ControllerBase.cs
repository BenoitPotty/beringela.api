 using System;
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
        public virtual PaginatedResult<T> Get([FromQuery]string search, [FromQuery]string sort = null, [FromQuery]bool descending = false, [FromQuery] uint page = 0, [FromQuery] uint pageSize = 0)
        {
            var pagingOptions = new PagingOptions(page, pageSize);
            
            var results = Service.TextualSearch(search, new SortOptions(sort, descending), pagingOptions);
            var totalCount = Service.TextualCount(search);

            return new PaginatedResult<T>(results, totalCount, pagingOptions);
        }

        [HttpGet("{id}")]
        public virtual T Get(Guid id)
        {
            return Service.Get(id);
        }

        [HttpPost]
        public virtual T Post(T entity)
        {
            return Service.Add(entity);
        }

        [HttpDelete("{id}")]
        public virtual T Post(Guid id)
        {
            return Service.Delete(id);
        }

        [HttpPatch("{id}")]
        public virtual T Patch(Guid id, [FromBody] JsonPatchDocument<T> patchData)
        {
            return Service.Patch(id, patchData);
        }
    }
}
