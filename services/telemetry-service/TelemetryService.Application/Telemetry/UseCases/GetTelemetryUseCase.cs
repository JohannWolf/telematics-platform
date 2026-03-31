using System;
using System.Collections.Generic;
using System.Text;
using TelemetryService.Application.Common;
using TelemetryService.Application.Telemetry.DTOs;
using TelemetryService.Domain.Telemetry.Repositories;

namespace TelemetryService.Application.Telemetry.UseCases
{
    public class GetTelemetryUseCase : IGetTelemetryUseCase
    {
        private readonly ITelemetryRepository _repo;

        public GetTelemetryUseCase(ITelemetryRepository repo)
        {
            _repo = repo;
        }

        public async Task<PagedResult<TelemetryResponseDto>> ExecuteAsync(GetTelemetryQueryDto query)
        {
            var (records, total) = await _repo.GetPagedAsync(
                query.VehicleId,
                query.From,
                query.To,
                query.Page,
                query.PageSize
            );

            var data = records.Select(t => new TelemetryResponseDto
            {
                VehicleId = t.VehicleId,
                Speed = t.Speed,
                EngineTemperature = t.EngineTemperature,
                FuelLevel = t.FuelLevel,
                Timestamp = t.Timestamp
            }).ToList();

            return new PagedResult<TelemetryResponseDto>
            {
                Data = data,
                Page = query.Page,
                PageSize = query.PageSize,
                TotalCount = total
            };
        }
    }
}
