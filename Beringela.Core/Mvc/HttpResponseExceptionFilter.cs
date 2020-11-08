using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using Beringela.Core.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Beringela.Core.Mvc
{
    public class HttpResponseExceptionFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Exception is EntityNotFoundException e)
            {
                context.Result = new ObjectResult(new
                {
                    Message = "The entity with the given Id has not been found",
                    Id = e.Id
                })
                {
                    StatusCode = (int)HttpStatusCode.NotFound
                };
            }
            context.ExceptionHandled = true;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
        }
    }
}
