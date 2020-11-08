using System;
using Beringela.Core.Entities;

namespace Beringela.Models.Entities
{
    public class WeatherForecast : DataEntity
    {
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        [TextualSearch]
        public string Summary { get; set; }
    }
}
