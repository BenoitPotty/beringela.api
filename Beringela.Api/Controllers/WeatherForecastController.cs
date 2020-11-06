using System.Collections.Generic;
using Beringela.Core.Mvc;
using Beringela.Core.Services;
using Beringela.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Beringela.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase<WeatherForecast>
    {
        public WeatherForecastController(ILogger<ControllerBase<WeatherForecast>> logger, IDataService<WeatherForecast> service) : base(logger, service)
        {
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            return Service.Select();
        }

        
    }
}
