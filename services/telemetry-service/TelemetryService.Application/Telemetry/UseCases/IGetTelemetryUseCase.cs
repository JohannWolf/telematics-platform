using TelemetryService.Application.Common;
using TelemetryService.Application.Telemetry.DTOs;

namespace TelemetryService.Application.Telemetry.UseCases
{
    public interface IGetTelemetryUseCase
    {
        Task<PagedResult<TelemetryResponseDto>> ExecuteAsync(GetTelemetryQueryDto query);
    }
}
