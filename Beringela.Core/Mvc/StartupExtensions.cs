using System.Linq;
using Beringela.Core.Configuration;
using Beringela.Core.Repositories;
using Beringela.Core.Services;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Options;

namespace Beringela.Core.Mvc
{
    public static class StartupExtensions
    {
        private const string DefaultSwaggerEndpointUrl = "/swagger/v1/swagger.json";
        private const string DefaultSwaggerEndpointName = "Change Me :-)";

        public static void AddBeringela<T>(this IServiceCollection services, IConfiguration appConfiguration = null) where T : DbContext
        {
            //Open for extension outside of core package => Action ça serait classe 
            services.AddSwaggerGen();

            services.AddControllers(options =>
            {
                options.Filters.Add(new HttpResponseExceptionFilter());
            }).AddNewtonsoftJson();

            var connectionString = appConfiguration.GetConnectionString("Database");

            services.AddHealthChecks()
                .AddCheck(nameof(GeneralHealthCheck), new GeneralHealthCheck(), HealthStatus.Unhealthy)
                .AddMySql(connectionString);
            
            services.AddScoped(typeof(IDataService<>), typeof(DataService<>));
            
            services.AddScoped(typeof(IDataRepository<>), typeof(DataRepository<>));
            
            services.AddDbContext<T>(options =>
            {
                options.UseMySQL(connectionString);
            });
            services.AddScoped<DbContext, T>();
        }

        public static void UseBeringela(this IApplicationBuilder app, IConfiguration appConfiguration = null)
        {
            var options = new BeringelaOptions();
            appConfiguration?.GetSection(BeringelaOptions.Beringela).Bind(options);

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint(options.Swagger?.Url ?? DefaultSwaggerEndpointUrl, options.Swagger?.Name ?? DefaultSwaggerEndpointName);
            });

            app.UseHealthChecks(options.HealthChecksUrl, new HealthCheckOptions()
            {
                Predicate = _ => true,
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            });
        }
    }
}
