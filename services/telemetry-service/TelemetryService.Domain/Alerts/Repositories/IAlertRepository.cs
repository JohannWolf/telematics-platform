using System;
using System.Collections.Generic;
using System.Text;
using TelemetryService.Domain.Alerts.Entities;

namespace TelemetryService.Domain.Alerts.Repositories
{
    public interface IAlertRepository
    {
        Task SaveAsync(Alert alert);
    }
}
