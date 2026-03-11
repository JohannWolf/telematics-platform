using Microsoft.EntityFrameworkCore;
using TelemetryService.Application.Telemetry.UseCases;
using TelemetryService.Domain.Alerts.Repositories;
using TelemetryService.Domain.Alerts.Services;
using TelemetryService.Domain.Rules.Repositories;
using TelemetryService.Domain.Rules.Services;
using TelemetryService.Domain.Telemetry.Repositories;
using TelemetryService.Infrastructure.Persistence;
using TelemetryService.Infrastructure.Persistence.Repositories.Alerts;
using TelemetryService.Infrastructure.Persistence.Repositories.Rules;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddScoped<IngestTelemetryUseCase>();
builder.Services.AddScoped<ITelemetryRepository, TelemetryRepository>();
builder.Services.AddScoped<IRuleEvaluator, RuleEvaluator>();
builder.Services.AddScoped<IAlertService, AlertService>();
builder.Services.AddScoped<IAlertRepository, AlertRepository>();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();


app.Run();

