using TelemetryService.Application.Auth.DTOs;
using TelemetryService.Domain.Auth.Repositories;

namespace TelemetryService.Application.Auth.UseCases;

public class GetCurrentUserUseCase
{
    private readonly IUserRepository _userRepository;

    public GetCurrentUserUseCase(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<UserDto> ExecuteAsync(Guid userId, CancellationToken cancellationToken = default)
    {
        var user = await _userRepository.GetByIdAsync(userId, cancellationToken);

        if (user == null)
        {
            throw new KeyNotFoundException("User not found");
        }

        return new UserDto
        {
            Id = user.Id,
            Email = user.Email,
            FirstName = user.FirstName,
            LastName = user.LastName,
            FullName = user.FullName,
            RoleId = user.RoleId,
            CreatedAt = user.CreatedAt,
            LastLoginAt = user.LastLoginAt
        };
    }
}