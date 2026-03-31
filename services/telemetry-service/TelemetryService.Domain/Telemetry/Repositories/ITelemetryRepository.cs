using TelemetryService.Domain.Telemetry.Entities;

namespace TelemetryService.Domain.Telemetry.Repositories
{
    public interface ITelemetryRepository
    {
        Task SaveAsync(TelemetryRecord telemetry);

        Task<List<TelemetryRecord>> GetLatestByVehicleAsync(Guid vehicleId, int limit);

        Task<(List<TelemetryRecord>, int totalCount)> GetPagedAsync(
            Guid vehicleId,
            DateTime? from,
            DateTime? to,
            int page,
            int pageSize
        );
    }
}
