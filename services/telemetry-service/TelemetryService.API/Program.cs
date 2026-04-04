using Microsoft.EntityFrameworkCore;
using TelemetryService.API.Extensions;
using TelemetryService.Application.Telemetry.UseCases;
using TelemetryService.Application.Vehicles.UseCases.CreateVehicle;
using TelemetryService.Application.Vehicles.UseCases.GetVehicles;
using TelemetryService.Domain.Alerts.Repositories;
using TelemetryService.Domain.Alerts.Services;
using TelemetryService.Domain.Rules.Services;
using TelemetryService.Domain.Telemetry.Repositories;
using TelemetryService.Domain.Vehicles.Repositories;
using TelemetryService.Infrastructure.Persistence;
using TelemetryService.Infrastructure.Persistence.Repositories.Alerts;
using TelemetryService.Infrastructure.Persistence.Repositories.Rules;
using TelemetryService.Infrastructure.Persistence.Repositories.Vehicles;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IngestTelemetryUseCase>();
builder.Services.AddScoped<ITelemetryRepository, TelemetryRepository>();
builder.Services.AddScoped<IRuleEvaluator, RuleEvaluator>();
builder.Services.AddScoped<IAlertService, AlertService>();
builder.Services.AddScoped<IAlertRepository, AlertRepository>();
builder.Services.AddScoped<IGetVehiclesUseCase, GetVehiclesUseCase>();
builder.Services.AddScoped<IVehicleRepository, VehicleRepository>();
builder.Services.AddScoped<ICreateVehicleUseCase, CreateVehicleUseCase>();

// Cross-cutting concerns
builder.Services.AddCorsServices(builder.Configuration);

// Feature-specific service registrations
builder.Services.AddAuthServices(builder.Configuration);

// Add Controllers
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseRouting();

// Use CORS
var corsPolicy = app.Configuration.GetCorsPolicyName();
app.UseCors(corsPolicy);

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

// Apply migrations
/*using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    dbContext.Database.Migrate();
}*/

app.Run();

