using Microsoft.AspNetCore.Mvc;
using TelemetryService.Application.Telemetry.DTOs;
using TelemetryService.Application.Telemetry.UseCases;

namespace TelemetryService.API.Controllers.Telemetry
{
    [ApiController]
    [Route("api/telemetry")]
    public class TelemetryController : ControllerBase
    {
        private readonly IngestTelemetryUseCase _useCase;
        private readonly IGetTelemetryUseCase _getTelemetryUseCase;

        public TelemetryController(IngestTelemetryUseCase useCase, IGetTelemetryUseCase getTelemetryUseCase)
        {
            _useCase = useCase;
            _getTelemetryUseCase = getTelemetryUseCase;
        }

        [HttpPost]
        public async Task<IActionResult> Ingest(TelemetryDto dto)
        {
            await _useCase.ExecuteAsync(dto);
            return Ok();
        }

        [HttpGet("{vehicleId}")]
        public async Task<IActionResult> GetTelemetry(
            Guid vehicleId,
            [FromQuery] DateTime? from,
            [FromQuery] DateTime? to,
            [FromQuery] int page = 1,
            [FromQuery] int pageSize = 50)
        {
            var query = new GetTelemetryQueryDto
            {
                VehicleId = vehicleId,
                From = from,
                To = to,
                Page = page,
                PageSize = pageSize
            };

            var result = await _getTelemetryUseCase.ExecuteAsync(query);

            return Ok(result);
        }
    }
}
