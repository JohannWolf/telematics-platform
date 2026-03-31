using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TelemetryService.Domain.Vehicles.Entities;
using TelemetryService.Domain.Vehicles.Repositories;

namespace TelemetryService.Infrastructure.Persistence.Repositories.Vehicles
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly AppDbContext _context;

        public VehicleRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Vehicle> CreateAsync(Vehicle vehicle)
        {
            await _context.Vehicles.AddAsync(vehicle);

            await _context.SaveChangesAsync();

            return vehicle;
        }

        public async Task<List<Vehicle>> GetAllAsync()
        {
            return await _context.Vehicles.ToListAsync();
        }

        public async Task<Vehicle?> GetByIdAsync(Guid id)
        {
            return await _context.Vehicles
                .FirstOrDefaultAsync(v => v.Id == id);
        }

        public async Task<Vehicle?> GetByNameAsync(string deviceId)
        {
            return await _context.Vehicles
                .FirstOrDefaultAsync(v => v.DeviceId == deviceId);
        }
    }
}
