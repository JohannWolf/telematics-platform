using System;
using System.Collections.Generic;
using System.Text;
using TelemetryService.Domain.Rules.Entities;

namespace TelemetryService.Domain.Rules.Repositories
{
    public interface IRuleRepository
    {
        Task<List<Rule>> GetEnabledRulesAsync(Guid tenantId);
    }
}
