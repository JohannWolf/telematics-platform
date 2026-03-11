using Microsoft.EntityFrameworkCore;
using TelemetryService.Domain.Alerts.Entities;
using TelemetryService.Domain.Rules.Entities;
using TelemetryService.Domain.Telemetry.Entities;
using TelemetryService.Domain.Vehicles.Entities;

namespace TelemetryService.Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public DbSet<TelemetryRecord> TelemetryRecords { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Rule> Rules { get; set; }

        public DbSet<Alert> Alerts { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
    }
}
