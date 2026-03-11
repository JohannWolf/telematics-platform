using System;
using System.Collections.Generic;
using System.Text;
using TelemetryService.Domain.Common;
using TelemetryService.Domain.Vehicles.Entities;

namespace TelemetryService.Domain.Telemetry.Entities
{
    public class TelemetryRecord : BaseEntity
    {
        public Guid TenantId { get; set; }

        public Guid VehicleId { get; set; }

        public double Speed { get; set; }

        public double EngineTemperature { get; set; }

        public double FuelLevel { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public DateTime Timestamp { get; set; }

        public Vehicle Vehicle { get; set; }
    }
}
