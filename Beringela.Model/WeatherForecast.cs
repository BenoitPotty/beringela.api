using System;

namespace Beringela.Models
{
    public class WeatherForecast
    {
        private static readonly Random Random = new Random();
        private static int _counter;
        private static readonly string[] Summaries = {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public WeatherForecast()
        {
            Date = DateTime.Now.AddDays(_counter++);
            TemperatureC = Random.Next(-20, 55);
            Summary = Summaries[Random.Next(Summaries.Length)];
        }

        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string Summary { get; set; }
    }
}
