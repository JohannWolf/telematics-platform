namespace TelemetryService.Application.Telemetry.DTOs
{
    public class GetTelemetryQueryDto
    {
        public Guid VehicleId { get; set; }

        public DateTime? From { get; set; }

        public DateTime? To { get; set; }

        public int Page { get; set; } = 1;

        public int PageSize { get; set; } = 50;
    }
}
