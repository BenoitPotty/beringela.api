using System;
using System.Net;
using Beringela.Core.Entities;

namespace Beringela.Core.Exceptions
{
    public class EntityUpdateException<T> : HttpResponseException where T: IDataEntity
    {
        public EntityUpdateException(T entity) : base(HttpStatusCode.UnprocessableEntity, $"Update entity of type {typeof(T).Name} with id {entity.Id} cannot be processed")
        {
            Entity = entity;
        }

        public T Entity { get; }    
    }
}
