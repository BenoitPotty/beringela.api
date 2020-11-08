using System;

namespace Beringela.Core.Mvc
{
    public class ErrorResult
    {
        public ErrorResult(Exception e)
        {
            Message = e.Message;
        }

        public string Message { get; set; }
    }
}
