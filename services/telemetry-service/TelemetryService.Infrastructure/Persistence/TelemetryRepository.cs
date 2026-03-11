using Microsoft.EntityFrameworkCore;
using TelemetryService.Domain.Telemetry.Entities;
using TelemetryService.Domain.Telemetry.Repositories;

namespace TelemetryService.Infrastructure.Persistence
{
    public class TelemetryRepository : ITelemetryRepository
    {
        private readonly AppDbContext _context;

        public TelemetryRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task SaveAsync(TelemetryRecord telemetry)
        {
            await _context.TelemetryRecords.AddAsync(telemetry);
            await _context.SaveChangesAsync();
        }

        public async Task<List<TelemetryRecord>> GetLatestByVehicleAsync(Guid vehicleId, int limit)
        {
            return await _context.TelemetryRecords
                .Where(t => t.VehicleId == vehicleId)
                .OrderByDescending(t => t.Timestamp)
                .Take(limit)
                .ToListAsync();
        }
    }
}
