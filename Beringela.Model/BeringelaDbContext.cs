using System.Linq;
using Beringela.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Beringela.Models
{
    public class BeringelaDbContext : DbContext
    {
        public DbSet<WeatherForecast> WeatherForecasts { get; set; }

        public BeringelaDbContext(DbContextOptions<BeringelaDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=localhost;port=3307;database=beringela;uid=beringela;password=beringela");
        }


        // TODO move in core
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //TODO Make generic
            modelBuilder
                .Entity<WeatherForecast>()
                .Property(w => w.Id)
                .HasConversion(new GuidToStringConverter());
            
            
            modelBuilder.Entity<WeatherForecast>()
                .HasData(Enumerable.Range(1, 5).Select(index => new WeatherForecast()));

        }
    }
}
