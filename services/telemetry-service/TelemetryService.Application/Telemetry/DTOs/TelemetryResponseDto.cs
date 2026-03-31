namespace TelemetryService.Application.Telemetry.DTOs
{
    public class TelemetryResponseDto
    {
        public Guid VehicleId { get; set; }

        public double Speed { get; set; }

        public double EngineTemperature { get; set; }

        public double FuelLevel { get; set; }

        public DateTime Timestamp { get; set; }
    }
}
