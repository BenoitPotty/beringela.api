using System;
using System.Net;

namespace Beringela.Core.Exceptions
{
    public class EntityNotFoundException<T> : HttpResponseException
    {
        public EntityNotFoundException(Guid id) : base(HttpStatusCode.NotFound, $"The entity of type {typeof(T).Name} with id {id} was not found")
        {
            Id = id;
        }

        public Guid Id { get; }    
    }
}
