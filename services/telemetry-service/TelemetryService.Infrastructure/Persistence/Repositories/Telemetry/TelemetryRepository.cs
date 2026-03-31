using Microsoft.EntityFrameworkCore;
using TelemetryService.Domain.Telemetry.Entities;

namespace TelemetryService.Infrastructure.Persistence.Repositories.Telemetry
{
    public class TelemetryRepository
    {
        public async Task<(List<TelemetryRecord>, int)> GetPagedAsync(
            Guid vehicleId,
            DateTime? from,
            DateTime? to,
            int page,
            int pageSize)
        {
            var query = _context.TelemetryRecords
                .Where(t => t.VehicleId == vehicleId);

            if (from.HasValue)
                query = query.Where(t => t.Timestamp >= from.Value);

            if (to.HasValue)
                query = query.Where(t => t.Timestamp <= to.Value);

            var totalCount = await query.CountAsync();

            var data = await query
                .OrderByDescending(t => t.Timestamp)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return (data, totalCount);
        }
    }
}
