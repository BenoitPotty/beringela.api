using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Beringela.Core.Extensions
{
    public static class StartupExtensions
    {
        public static void AddBeringela(this IServiceCollection services)
        {
            services.AddSwaggerGen();
        }

        public static void UseBeringela(this IApplicationBuilder app)
        {
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                // TODO get those strings from a Beringela Config section in app.settings.json
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

        }
    }
}
