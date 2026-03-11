using System;
using System.Collections.Generic;
using System.Text;
using TelemetryService.Domain.Telemetry.Entities;

namespace TelemetryService.Domain.Telemetry.Repositories
{
    public interface ITelemetryRepository
    {
        Task SaveAsync(TelemetryRecord telemetry);

        Task<List<TelemetryRecord>> GetLatestByVehicleAsync(Guid vehicleId, int limit);
    }
}
