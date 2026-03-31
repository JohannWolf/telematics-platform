using TelemetryService.Application.Vehicles.DTOs;
using TelemetryService.Domain.Vehicles.Entities;
using TelemetryService.Domain.Vehicles.Repositories;

namespace TelemetryService.Application.Vehicles.UseCases.CreateVehicle
{
    public class CreateVehicleUseCase : ICreateVehicleUseCase
    {
        private readonly IVehicleRepository _vehicleRepository;

        public CreateVehicleUseCase(IVehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }

        public async Task<VehicleDto> ExecuteAsync(CreateVehicleDto dto)
        {
            var vehicle = new Vehicle
            {
                Id = Guid.NewGuid(),
                TenantId = dto.TenantId,
                DeviceId = dto.DeviceId,
                Name = dto.Name
            };

            var created = await _vehicleRepository.CreateAsync(vehicle);

            return new VehicleDto
            {
                Id = created.Id,
                Name = created.Name,
                DeviceId = created.DeviceId
            };
        }
    }
}
