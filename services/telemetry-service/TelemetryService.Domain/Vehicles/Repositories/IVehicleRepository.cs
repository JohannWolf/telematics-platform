using System;
using System.Collections.Generic;
using System.Text;
using TelemetryService.Domain.Vehicles.Entities;

namespace TelemetryService.Domain.Vehicles.Repositories
{
    public interface IVehicleRepository
    {
        Task<Vehicle?> GetByIdAsync(Guid vehicleId);

        Task<Vehicle?> GetByNameAsync(string name);
    }
}
