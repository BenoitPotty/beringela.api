using System;
using System.Linq;
using System.Reflection;
using Beringela.Core.Entities;
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
            //TODO crashes when data already in database
            //modelBuilder.Entity<WeatherForecast>()
            //    .HasData(Enumerable.Range(1, 5).Select(index => new WeatherForecast()));


            foreach (var property in modelBuilder.Model.GetEntityTypes().SelectMany(t => t.GetProperties()))
            {
                if (property.ClrType != typeof(Guid)) continue;
                var converterType = typeof(GuidToStringConverter);
                var setValueConverterMethodInfo = typeof(MutablePropertyExtensions).GetMethod("SetValueConverter");
                setValueConverterMethodInfo.Invoke(property, new[] { property, Activator.CreateInstance(converterType, (object)null) });
            }
        }
    }
}
