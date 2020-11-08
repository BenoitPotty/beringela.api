using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.Extensions.Configuration;

namespace Beringela.Core.Entities
{
    public abstract class MySqlDbContext : DbContext
    {
        protected string ConnectionString { get; set; }

        protected MySqlDbContext(DbContextOptions options, IConfiguration appConfiguration) : base(options)
        {
            ConnectionString = appConfiguration.GetConnectionString("DevDatabase");
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL(ConnectionString);
        }


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
