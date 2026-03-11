using TelemetryService.Domain.Common;

namespace TelemetryService.Domain.Alerts.Entities
{
    public class Alert : BaseEntity
    {
        public Guid TenantId { get; set; }

        public Guid VehicleId { get; set; }

        public Guid RuleId { get; set; }

        public string Message { get; set; }

        public DateTime TriggeredAt { get; set; }

        public bool Acknowledged { get; set; }
    }
}
