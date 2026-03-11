using Microsoft.AspNetCore.Mvc;
using TelemetryService.Application.Telemetry.DTOs;
using TelemetryService.Application.Telemetry.UseCases;

namespace TelemetryService.API.Controllers
{
    [ApiController]
    [Route("api/telemetry")]
    public class TelemetryController : ControllerBase
    {
        private readonly IngestTelemetryUseCase _useCase;

        public TelemetryController(IngestTelemetryUseCase useCase)
        {
            _useCase = useCase;
        }

        [HttpPost]
        public async Task<IActionResult> Ingest(TelemetryDto dto)
        {
            await _useCase.Execute(dto);
            return Ok();
        }
    }
}
