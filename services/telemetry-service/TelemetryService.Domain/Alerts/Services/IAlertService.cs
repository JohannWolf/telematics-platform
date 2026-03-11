using TelemetryService.Domain.Rules.Entities;
using TelemetryService.Domain.Telemetry.Entities;

namespace TelemetryService.Domain.Alerts.Services
{
    public interface IAlertService
    {
        public Task CreateAlertAsync(Rule rule, TelemetryRecord telemetry);
    }
}
