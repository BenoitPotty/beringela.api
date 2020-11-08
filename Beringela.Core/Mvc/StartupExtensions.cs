using Beringela.Core.Configuration;
using Beringela.Core.Repositories;
using Beringela.Core.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

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

            services.AddControllers(options => options.Filters.Add(new HttpResponseExceptionFilter()));
            
            
            services.AddScoped(typeof(IDataService<>), typeof(DataService<>));
            
            services.AddScoped(typeof(IDataRepository<>), typeof(DataRepository<>));
            
            services.AddDbContext<T>(options => options.UseMySQL(appConfiguration.GetConnectionString("Database")));
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

        }
    }
}
