using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TelemetryService.Application.Auth.DTOs;
using TelemetryService.Application.Auth.UseCases;
using TelemetryService.Application.Auth.Common;

namespace TelemetryService.API.Controllers.Auth;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly LoginUseCase _loginUseCase;
    private readonly RegisterUseCase _registerUseCase;
    private readonly RefreshTokenUseCase _refreshTokenUseCase;
    private readonly GetCurrentUserUseCase _getCurrentUserUseCase;
    private readonly ICurrentUserService _currentUserService;

    public AuthController(
        LoginUseCase loginUseCase,
        RegisterUseCase registerUseCase,
        RefreshTokenUseCase refreshTokenUseCase,
        GetCurrentUserUseCase getCurrentUserUseCase,
        ICurrentUserService currentUserService)
    {
        _loginUseCase = loginUseCase;
        _registerUseCase = registerUseCase;
        _refreshTokenUseCase = refreshTokenUseCase;
        _getCurrentUserUseCase = getCurrentUserUseCase;
        _currentUserService = currentUserService;
    }

    [HttpPost("login")]
    public async Task<ActionResult<LoginResponse>> Login([FromBody] LoginRequest request)
    {
        var ipAddress = GetIpAddress();
        var response = await _loginUseCase.ExecuteAsync(request, ipAddress);
        return Ok(response);
    }

    [HttpPost("register")]
    public async Task<ActionResult<UserDto>> Register([FromBody] RegisterRequest request)
    {
        var response = await _registerUseCase.ExecuteAsync(request);
        return Ok(response);
    }

    [HttpPost("refresh")]
    public async Task<ActionResult<LoginResponse>> Refresh([FromBody] RefreshTokenRequest request)
    {
        var ipAddress = GetIpAddress();
        var response = await _refreshTokenUseCase.ExecuteAsync(request.RefreshToken, ipAddress);
        return Ok(response);
    }

    [Authorize]
    [HttpGet("me")]
    public async Task<ActionResult<UserDto>> GetCurrentUser()
    {
        if (!_currentUserService.UserId.HasValue)
            return Unauthorized();

        var user = await _getCurrentUserUseCase.ExecuteAsync(_currentUserService.UserId.Value);
        return Ok(user);
    }

    [Authorize]
    [HttpPost("logout")]
    public async Task<IActionResult> Logout()
    {
        // The actual token revocation is handled on the client side
        // TODO ***** implement token blacklisting
        return Ok(new { message = "Logged out successfully" });
    }

    private string GetIpAddress()
    {
        if (Request.Headers.ContainsKey("X-Forwarded-For"))
            return Request.Headers["X-Forwarded-For"].ToString();

        return HttpContext.Connection.RemoteIpAddress?.MapToIPv4().ToString() ?? "unknown";
    }
}