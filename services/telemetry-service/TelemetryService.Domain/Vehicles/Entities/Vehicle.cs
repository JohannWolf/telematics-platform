using TelemetryService.Domain.Common;
using TelemetryService.Domain.Telemetry.Entities;
using TelemetryService.Domain.Tenants.Entities;

namespace TelemetryService.Domain.Vehicles.Entities
{
    public class Vehicle : BaseEntity
    {
        public Guid TenantId { get; set; }
        public string Vin {  get; set; }
        public string Brand { get; set; }
        public string Year { get; set; }
        public string Model { get; set; }
        public string EngineType { get; set; }
        public string EngineVersion { get; set; }
        public string Name { get; set; }
        public string DeviceId { get; set; }
        public Tenant Tenant { get; set; }
        public ICollection<TelemetryRecord> TelemetryRecords { get; set; }
    }
}
