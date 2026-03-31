using Microsoft.AspNetCore.Mvc;
using TelemetryService.Application.Vehicles.DTOs;
using TelemetryService.Application.Vehicles.UseCases.CreateVehicle;
using TelemetryService.Application.Vehicles.UseCases.GetVehicles;

namespace TelemetryService.API.Controllers.Vehicles
{
    [ApiController]
    [Route("api/[controller]")]
    public class VehicleController : ControllerBase
    {
        private readonly ICreateVehicleUseCase _createVehicleUseCase;
        private readonly IGetVehiclesUseCase _getVehiclesUseCase;

        public VehicleController(
            ICreateVehicleUseCase createVehicleUseCase,
            IGetVehiclesUseCase getVehiclesUseCase)
        {
            _createVehicleUseCase = createVehicleUseCase;
            _getVehiclesUseCase = getVehiclesUseCase;
        }

        [HttpPost]
        public async Task<IActionResult> CreateVehicle(CreateVehicleDto dto)
        {
            var vehicle = await _createVehicleUseCase.ExecuteAsync(dto);

            return Ok(vehicle);
        }

        [HttpGet]
        public async Task<IActionResult> GetVehicles()
        {
            var vehicles = await _getVehiclesUseCase.ExecuteAsync();

            return Ok(vehicles);
        }
    }
}
