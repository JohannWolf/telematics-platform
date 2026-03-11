using System;
using System.Collections.Generic;
using System.Text;

namespace TelemetryService.Application.Interfaces
{
    public interface INotificationService
    {
        Task SendAsync(string message);
    }
}
