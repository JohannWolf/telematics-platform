using System.IdentityModel.Tokens.Jwt;
using TelemetryService.Application.Auth.Common;
using TelemetryService.Application.Auth.DTOs;
using TelemetryService.Domain.Auth.Entities;
using TelemetryService.Domain.Auth.Repositories;

namespace TelemetryService.Application.Auth.UseCases;

public class RefreshTokenUseCase
{
    private readonly IUserRepository _userRepository;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    public RefreshTokenUseCase(
        IUserRepository userRepository,
        IJwtTokenGenerator jwtTokenGenerator)
    {
        _userRepository = userRepository;
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public async Task<LoginResponse> ExecuteAsync(string refreshToken, string ipAddress, CancellationToken cancellationToken = default)
    {
        // Get refresh token from database
        var storedRefreshToken = await _userRepository.GetRefreshTokenAsync(refreshToken, cancellationToken);

        if (storedRefreshToken == null || !storedRefreshToken.IsActive)
        {
            throw new UnauthorizedAccessException("Invalid or expired refresh token");
        }

        // Get user
        var user = await _userRepository.GetByIdAsync(storedRefreshToken.UserId, cancellationToken);
        if (user == null || !user.IsActive)
        {
            throw new UnauthorizedAccessException("User not found or deactivated");
        }

        // Revoke old refresh token
        storedRefreshToken.IsRevoked = true;
        storedRefreshToken.RevokedAt = DateTime.UtcNow;
        storedRefreshToken.RevokedByIp = ipAddress;
        await _userRepository.UpdateRefreshTokenAsync(storedRefreshToken, cancellationToken);

        // Generate new tokens
        var newAccessToken = _jwtTokenGenerator.GenerateAccessToken(user);
        var newRefreshToken = _jwtTokenGenerator.GenerateRefreshToken();
        var expiresAt = _jwtTokenGenerator.GetAccessTokenExpiration();

        // Save new refresh token
        var newRefreshTokenEntity = new RefreshToken
        {
            Token = newRefreshToken,
            UserId = user.Id,
            ExpiresAt = DateTime.UtcNow.AddDays(7),
            CreatedByIp = ipAddress
        };

        await _userRepository.AddRefreshTokenAsync(newRefreshTokenEntity, cancellationToken);

        return new LoginResponse
        {
            AccessToken = newAccessToken,
            RefreshToken = newRefreshToken,
            ExpiresAt = expiresAt,
            User = new UserDto
            {
                Id = user.Id,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                FullName = user.FullName,
                RoleId = user.RoleId,
                CreatedAt = user.CreatedAt,
                LastLoginAt = user.LastLoginAt
            }
        };
    }
}