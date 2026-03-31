using System;
using System.Collections.Generic;
using System.Text;
using TelemetryService.Application.Vehicles.DTOs;
using TelemetryService.Domain.Vehicles.Repositories;

namespace TelemetryService.Application.Vehicles.UseCases.GetVehicles
{
    public class GetVehiclesUseCase : IGetVehiclesUseCase
    {
        private readonly IVehicleRepository _vehicleRepository;

        public GetVehiclesUseCase(IVehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }

        public async Task<List<VehicleDto>> ExecuteAsync()
        {
            var vehicles = await _vehicleRepository.GetAllAsync();

            return vehicles.Select(v => new VehicleDto
            {
                Id = v.Id,
                Name = v.Name,
                DeviceId = v.DeviceId
            }).ToList();
        }
    }
}
