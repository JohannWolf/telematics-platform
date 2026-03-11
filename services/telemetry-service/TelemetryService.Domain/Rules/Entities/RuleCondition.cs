using System;
using System.Collections.Generic;
using System.Text;

namespace TelemetryService.Domain.Rules.Entities
{
    public class RuleCondition
    {
        public string Metric { get; set; }

        public string Operator { get; set; }

        public double Value { get; set; }
    }
}
