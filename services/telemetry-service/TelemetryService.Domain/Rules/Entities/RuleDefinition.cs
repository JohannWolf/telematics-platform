using System;
using System.Collections.Generic;
using System.Text;

namespace TelemetryService.Domain.Rules.Entities
{
    public class RuleDefinition
    {
        public string Logic { get; set; }

        public List<RuleCondition> Conditions { get; set; }
    }
}
