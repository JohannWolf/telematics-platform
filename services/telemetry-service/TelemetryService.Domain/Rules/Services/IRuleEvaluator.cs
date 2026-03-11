using TelemetryService.Domain.Rules.Entities;
using TelemetryService.Domain.Telemetry.Entities;

namespace TelemetryService.Domain.Rules.Services
{
    public interface IRuleEvaluator
    {
        public bool Evaluate(Rule rule, TelemetryRecord telemetry);

        public bool EvaluateCondition(RuleCondition condition, TelemetryRecord telemetry);

        public double GetMetricValue(string metric, TelemetryRecord telemetry);
    }
}
