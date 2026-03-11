using System.Text.Json;
using TelemetryService.Domain.Rules.Entities;
using TelemetryService.Domain.Rules.Services;
using TelemetryService.Domain.Telemetry.Entities;

namespace TelemetryService.Infrastructure.Persistence.Repositories.Rules
{
    public class RuleEvaluator : IRuleEvaluator
    {
        public bool Evaluate(Rule rule, TelemetryRecord telemetry)
        {
            var definition = JsonSerializer.Deserialize<RuleDefinition>(rule.RuleDefinition);

            if (definition == null)
                return false;

            if (definition.Logic == "AND")
            {
                return definition.Conditions.All(c => EvaluateCondition(c, telemetry));
            }

            if (definition.Logic == "OR")
            {
                return definition.Conditions.Any(c => EvaluateCondition(c, telemetry));
            }

            return false;
        }

        public bool EvaluateCondition(RuleCondition condition, TelemetryRecord telemetry)
        {
            var metricValue = GetMetricValue(condition.Metric, telemetry);

            return condition.Operator switch
            {
                ">" => metricValue > condition.Value,
                "<" => metricValue < condition.Value,
                "=" => metricValue == condition.Value,
                ">=" => metricValue >= condition.Value,
                "<=" => metricValue <= condition.Value,
                _ => false
            };
        }

        public double GetMetricValue(string metric, TelemetryRecord telemetry)
        {
            return metric switch
            {
                "speed" => telemetry.Speed,
                "engine_temperature" => telemetry.EngineTemperature,
                "fuel_level" => telemetry.FuelLevel,
                _ => 0
            };
        }
    }
}
