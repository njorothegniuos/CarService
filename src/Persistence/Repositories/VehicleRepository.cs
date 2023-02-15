using Domain.Entities;
using Domain.Repositories;
using Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories
{
    internal sealed class VehicleRepository : IVehicleRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public VehicleRepository(ApplicationDbContext dbContext) =>
            _dbContext = dbContext;

        public void Add(Vehicle vehicle) =>
            _dbContext.Set<Vehicle>().Add(vehicle);

        public async Task<Vehicle?> GetVehicleByIdAsync(Guid id, CancellationToken cancellationToken = default) =>
        await _dbContext
            .Set<Vehicle>()
            .FirstOrDefaultAsync(member => member.Id == id, cancellationToken);

        public async Task<bool> IsRegistrationNumberUniqueAsync(
       RegistrationNumber registrationNumber,
       CancellationToken cancellationToken = default) =>
       !await _dbContext
           .Set<Vehicle>()
           .AnyAsync(vehicle => vehicle.RegistrationNumber == registrationNumber, cancellationToken);

    }
}
