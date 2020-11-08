using System;
using System.Net;

namespace Beringela.Core.Exceptions
{
    public class HttpResponseException : Exception
    {
        public HttpResponseException(HttpStatusCode statusCode, string message = "Error") : base (message)
        {
            StatusCode = statusCode;
        }

        public HttpStatusCode StatusCode { get; }  
    }
}
