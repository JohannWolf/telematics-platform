 using TelemetryService.Domain.Alerts.Entities;
using TelemetryService.Domain.Alerts.Repositories;

namespace TelemetryService.Infrastructure.Persistence.Repositories.Alerts
{
    public class AlertRepository : IAlertRepository
    {
        private readonly AppDbContext _context;

        public AlertRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task SaveAsync(Alert alert)
        {
            await _context.Alerts.AddAsync(alert);
            await _context.SaveChangesAsync();
        }
    }
}
