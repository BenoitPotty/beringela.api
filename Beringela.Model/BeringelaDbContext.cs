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
    }
}
