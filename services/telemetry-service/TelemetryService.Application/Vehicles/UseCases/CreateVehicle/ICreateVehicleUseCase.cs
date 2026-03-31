using System;
using System.Collections.Generic;
using System.Text;
using TelemetryService.Application.Vehicles.DTOs;

namespace TelemetryService.Application.Vehicles.UseCases.CreateVehicle
{
    public interface ICreateVehicleUseCase
    {
        Task<VehicleDto> ExecuteAsync(CreateVehicleDto dto);
    }
}
