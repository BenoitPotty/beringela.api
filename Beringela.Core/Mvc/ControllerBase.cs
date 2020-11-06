using Beringela.Core.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Beringela.Core.Mvc
{
    public class ControllerBase<T> : ControllerBase
    {
        public IDataService<T> Service { get; }
        private ILogger<ControllerBase<T>> Logger { get; }

        public ControllerBase(ILogger<ControllerBase<T>> logger, IDataService<T> service)
        {
            Service = service;
            Logger = logger;
        }

        // TODO : Move Basic Methods here
    }
}
