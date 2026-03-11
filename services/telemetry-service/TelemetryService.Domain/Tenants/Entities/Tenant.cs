using TelemetryService.Domain.Common;
using TelemetryService.Domain.Vehicles.Entities;

namespace TelemetryService.Domain.Tenants.Entities
{
    public class Tenant : BaseEntity
    {
        public string Name { get; set; }

        public ICollection<Vehicle> Vehicles { get; set; }
    }
}
