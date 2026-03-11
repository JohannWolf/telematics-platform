using System;
using System.Collections.Generic;
using System.Text;
using TelemetryService.Domain.Common;

namespace TelemetryService.Domain.Rules.Entities
{
    public class Rule : BaseEntity
    {
        public Guid TenantId { get; set; }

        public string Name { get; set; }

        public bool Enabled { get; set; }

        public string RuleDefinition { get; set; }
    }
}
