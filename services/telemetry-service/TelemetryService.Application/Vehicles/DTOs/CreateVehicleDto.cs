using System;
using System.Collections.Generic;
using System.Text;

namespace TelemetryService.Application.Vehicles.DTOs
{
    public class CreateVehicleDto
    {
        public Guid TenantId { get; set; }

        public string DeviceId { get; set; }

        public string Name { get; set; }
    }
}
