using TelemetryService.Application.Telemetry.DTOs;
using TelemetryService.Domain.Alerts.Services;
using TelemetryService.Domain.Rules.Repositories;
using TelemetryService.Domain.Rules.Services;
using TelemetryService.Domain.Telemetry.Entities;
using TelemetryService.Domain.Telemetry.Repositories;

namespace TelemetryService.Application.Telemetry.UseCases
{ 
    public class IngestTelemetryUseCase
    {
        private ITelemetryRepository _telemetryRepository;
        private IRuleEvaluator _ruleEvaluator;
        private IAlertService _alertService;
        private IRuleRepository _ruleRepository;
        public IngestTelemetryUseCase(ITelemetryRepository telemetryRepository, IRuleEvaluator ruleEvaluator, IAlertService alertService, IRuleRepository ruleRepository)
        {
            _telemetryRepository = telemetryRepository;
            _ruleEvaluator = ruleEvaluator;
            _alertService = alertService;
            _ruleRepository = ruleRepository;
        }
        public async Task ExecuteAsync(TelemetryDto dto)
        {
            var telemetry = new TelemetryRecord
            {
                Id = Guid.NewGuid(),
                TenantId = dto.TenantId,
                VehicleId = dto.VehicleId,
                Speed = dto.Speed,
                EngineTemperature = dto.EngineTemperature,
                FuelLevel = dto.FuelLevel,
                Latitude = dto.Latitude,
                Longitude = dto.Longitude,
                Timestamp = dto.Timestamp
            };

            await _telemetryRepository.SaveAsync(telemetry);

            var rules = await _ruleRepository.GetEnabledRulesAsync(dto.TenantId);

            foreach (var rule in rules)
            {
                var matched = _ruleEvaluator.Evaluate(rule, telemetry);

                if (matched)
                {
                    await _alertService.CreateAlertAsync(rule, telemetry);
                }
            }
        }
    }
}
