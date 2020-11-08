using System;
using System.Linq;
using Beringela.Core.Entities;
using Beringela.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Beringela.Models
{
    public class BeringelaDbContext : MySqlDbContext
    {
        public DbSet<WeatherForecast> WeatherForecasts { get; set; }

        public BeringelaDbContext(DbContextOptions<BeringelaDbContext> options, IConfiguration appConfiguration)
            : base(options, appConfiguration)
        {
            ConnectionString = appConfiguration.GetConnectionString("DataBase");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<WeatherForecast>()
                .HasData(
                    new[]
                    {
                        new WeatherForecast
                        {
                            Id = Guid.Parse("2485397e-5a03-4fab-8df8-526a5b15f7b9"),
                            Date = new DateTime(2020, 11, 07, 12, 0, 0),
                            TemperatureC = 26,
                            Summary = "Warm"
                        },
                        new WeatherForecast
                        {
                            Id = Guid.Parse("4e017299-0191-4527-b2f7-1c4134a8412e"),
                            Date = new DateTime(2020, 11, 08, 12, 0, 0),
                            TemperatureC = 18,
                            Summary = "Chilly"
                        },
                        new WeatherForecast
                        {
                            Id = Guid.Parse("b36e107a-e474-48b7-9bfa-6762c6f1361b"),
                            Date = new DateTime(2020, 11, 09, 12, 0, 0),
                            TemperatureC = 7,
                            Summary = "Bracing"
                        }
                        ,
                        new WeatherForecast
                        {
                            Id = Guid.Parse("ede8d5cc-72e0-44c2-adca-cb810f161596"),
                            Date = new DateTime(2020, 11, 10, 12, 0, 0),
                            TemperatureC = 21,
                            Summary = "Warm"
                        }
                    });
        }
    }
}
