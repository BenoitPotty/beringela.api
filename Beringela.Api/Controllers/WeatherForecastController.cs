using Beringela.Core.Mvc;
using Beringela.Core.Services;
using Beringela.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Beringela.Api.Controllers
{
    //TODO : Move attributes
    [ApiController]
    //TODO : add base route from config => configure routes startup or program
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase<WeatherForecast>
    {
        public WeatherForecastController(ILogger<ControllerBase<WeatherForecast>> logger, IDataService<WeatherForecast> service) : base(logger, service)
        {
        }
    }
}
