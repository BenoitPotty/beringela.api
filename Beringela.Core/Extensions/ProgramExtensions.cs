using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog.Web;

namespace Beringela.Core.Extensions
{
    public static class ProgramExtensions
    {
        public static IHostBuilder ConfigureBeringela(this IHostBuilder hostBuilder)
        {
            hostBuilder.ConfigureLogging(logging =>
                {
                    logging.ClearProviders();
                    logging.SetMinimumLevel(LogLevel.Trace);
                })
                .UseNLog();
            return hostBuilder;
        }
    }
}
