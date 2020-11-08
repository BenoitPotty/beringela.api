using System;
using System.Net;

namespace Beringela.Core.Exceptions
{
    public class EntityNotFoundException : HttpResponseException
    {
        public EntityNotFoundException(Guid id) : base(HttpStatusCode.NotFound)
        {
            Id = id;
        }

        public Guid Id { get; }    
    }
}
