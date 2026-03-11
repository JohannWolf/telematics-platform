using System;
using System.Collections.Generic;
using System.Text;

namespace TelemetryService.Application.Telemetry.DTOs
{
    public class TelemetryDto
    {
        public Guid TenantId { get; set; }

        public Guid VehicleId { get; set; }

        public double Speed { get; set; }

        public double EngineTemperature { get; set; }

        public double FuelLevel { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public DateTime Timestamp { get; set; }
    }
}
