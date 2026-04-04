using System.Security.Claims;
using TelemetryService.Domain.Auth.Entities;

namespace TelemetryService.Application.Auth.Common;

public interface IJwtTokenGenerator
{
    string GenerateAccessToken(User user);
    string GenerateRefreshToken();
    ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
    DateTime GetAccessTokenExpiration();
}