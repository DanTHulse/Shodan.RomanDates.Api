using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace Shodan.RomanDates.Api.HealthChecks
{
    public class DefaultHealthCheck : IHealthCheck
    {
        public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
            => Task.FromResult(HealthCheckResult.Healthy("A healthy result."));
    }
}
