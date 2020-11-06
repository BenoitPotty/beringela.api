using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Beringela.Core.Mvc
{
    public class ControllerBase<T> : ControllerBase
    {
        private readonly ILogger<ControllerBase<T>> _logger;

        public ControllerBase(ILogger<ControllerBase<T>> logger)
        {
            _logger = logger;
        }

        // TODO : Move Basic Methods here
    }
}
