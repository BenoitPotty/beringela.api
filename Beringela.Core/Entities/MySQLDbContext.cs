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

        protected MySqlDbContext(IConfiguration appConfiguration)
        {
            ConnectionString = appConfiguration.GetConnectionString("DevDatabase");
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(ConnectionString, ServerVersion.AutoDetect(ConnectionString));
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
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
