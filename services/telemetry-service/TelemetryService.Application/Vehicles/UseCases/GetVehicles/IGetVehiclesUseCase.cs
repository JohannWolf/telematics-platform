using System;
using System.Collections.Generic;
using System.Text;
using TelemetryService.Application.Vehicles.DTOs;
using TelemetryService.Domain.Vehicles.Entities;
using TelemetryService.Domain.Vehicles.Repositories;

namespace TelemetryService.Application.Vehicles.UseCases.GetVehicles
{
    public interface IGetVehiclesUseCase
    {
        Task<List<VehicleDto>> ExecuteAsync();
    }
}
