using System;
using System.Collections.Generic;
using System.Text;

namespace TelemetryService.Application.Vehicles.DTOs
{
    //response dto
    public class VehicleDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string DeviceId { get; set; }
    }
}
