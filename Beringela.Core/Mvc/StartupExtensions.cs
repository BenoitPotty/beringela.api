using Beringela.Core.Configuration;
using Beringela.Core.Repositories;
using Beringela.Core.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Beringela.Core.Mvc
{
    public static class StartupExtensions
    {
        private const string DefaultSwaggerEndpointUrl = "/swagger/v1/swagger.json";
        private const string DefaultSwaggerEndpointName = "Change Me :-)";

        public static void AddBeringela(this IServiceCollection services)
        {
            services.AddSwaggerGen();
            services.AddScoped(typeof(IDataService<>), typeof(DataService<>));
            services.AddScoped(typeof(IDataRepository<>), typeof(DataRepository<>));
        }

        //TODO : To Test
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
