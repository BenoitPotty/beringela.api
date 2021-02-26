using Beringela.Core.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Beringela.Core.Mvc
{
    public class HttpResponseExceptionFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Exception is not HttpResponseException e) return;

            context.Result = new ObjectResult(new ErrorResult(e))
            {
                StatusCode = (int)e.StatusCode,
            };

            context.ExceptionHandled = true;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
        }
    }
}
