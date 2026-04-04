namespace TelemetryService.API.Extensions;

public static class CorsServiceExtensions
{
    public static IServiceCollection AddCorsServices(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        // Get CORS settings from configuration
        var corsSettings = configuration.GetSection("CorsSettings");
        var environment = configuration["ASPNETCORE_ENVIRONMENT"] ?? "Development";

        services.AddCors(options =>
        {
            // Development-specific CORS policy (permissive)
            if (environment == "Development")
            {
                options.AddPolicy("Development", policy =>
                {
                    policy.AllowAnyOrigin()
                          .AllowAnyMethod()
                          .AllowAnyHeader();
                });
            }

            // Staging/Production policy (restrictive)
            options.AddPolicy("TelemetryPlatform", policy =>
            {
                var allowedOrigins = corsSettings.GetSection("AllowedOrigins").Get<string[]>()
                    ?? new[] { "http://localhost:5173", "http://localhost:3000" };

                policy.WithOrigins(allowedOrigins)
                      .WithMethods("GET", "POST", "PUT", "DELETE", "PATCH", "OPTIONS")
                      .WithHeaders("Authorization", "Content-Type", "Accept", "X-Requested-With")
                      .WithExposedHeaders("Content-Disposition", "Token-Expired")
                      .AllowCredentials()
                      .SetPreflightMaxAge(TimeSpan.FromMinutes(10));
            });
        });

        return services;
    }

    // Method to get the appropriate policy name based on environment
    public static string GetCorsPolicyName(this IConfiguration configuration)
    {
        var environment = configuration["ASPNETCORE_ENVIRONMENT"] ?? "Development";

        return environment == "Development" ? "Development" : "TelemetryPlatform";
    }
}