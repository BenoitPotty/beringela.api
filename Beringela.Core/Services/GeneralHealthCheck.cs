using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Beringela.Core.Entities;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace Beringela.Core.Services
{
    public class GeneralHealthCheck : IHealthCheck
    {
        public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = new CancellationToken())
        {
            var healthData = new Dictionary<string, object>
            {
                { "Api", new HealthData() }
            };
            return Task.Run(() => HealthCheckResult.Healthy("BasicHealth", healthData), cancellationToken);
        }
    }
}
