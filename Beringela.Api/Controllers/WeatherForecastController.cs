using Beringela.Core.Mvc;
using Beringela.Core.Services;
using Beringela.Models.Entities;
using Microsoft.Extensions.Logging;

namespace Beringela.Api.Controllers
{
    public class WeatherForecastController : ControllerBase<WeatherForecast>
    {
        public WeatherForecastController(ILogger<ControllerBase<WeatherForecast>> logger, IDataService<WeatherForecast> service) : base(logger, service)
        {
        }
    }
}
