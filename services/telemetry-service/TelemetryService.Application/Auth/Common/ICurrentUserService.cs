using System.Security.Claims;

namespace TelemetryService.Application.Auth.Common;

public interface ICurrentUserService
{
    Guid? UserId { get; }
    string? Email { get; }
    string? Role { get; }
    bool IsAuthenticated { get; }
    ClaimsPrincipal? User { get; }
}