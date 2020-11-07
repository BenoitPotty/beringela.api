using System;
using Beringela.Core.Entities;

namespace Beringela.Models.Entities
{
    public class WeatherForecast : DataEntity
    {
        private static readonly Random Random = new Random();
        private static int _counter;

        private static readonly string[] Summaries =
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        public WeatherForecast()
        {
            Date = DateTime.Now.AddDays(_counter++);
            TemperatureC = Random.Next(-20, 55);
            Summary = Summaries[Random.Next(Summaries.Length)];
        }

        public Guid Id { get; set; }

        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        [TextualSearch]
        public string Summary { get; set; }
    }
}
