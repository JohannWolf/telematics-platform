using TelemetryService.Domain.Alerts.Entities;
using TelemetryService.Domain.Alerts.Repositories;
using TelemetryService.Domain.Alerts.Services;
using TelemetryService.Domain.Rules.Entities;
using TelemetryService.Domain.Telemetry.Entities;

namespace TelemetryService.Infrastructure.Persistence.Repositories.Alerts
{
    public class AlertService : IAlertService
    {
        private readonly IAlertRepository _alertRepository;

        public AlertService(IAlertRepository alertRepository)
        {
            _alertRepository = alertRepository;
        }

        public async Task CreateAlertAsync(Rule rule, TelemetryRecord telemetry)
        {
            var alert = new Alert
            {
                Id = Guid.NewGuid(),
                TenantId = telemetry.TenantId,
                VehicleId = telemetry.VehicleId,
                RuleId = rule.Id,
                Message = $"Rule triggered: {rule.Name}",
                TriggeredAt = DateTime.UtcNow,
                Acknowledged = false
            };

            await _alertRepository.SaveAsync(alert);
        }
    }
}
