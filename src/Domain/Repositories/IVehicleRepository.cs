using Domain.Entities;
using Domain.ValueObjects;

namespace Domain.Repositories
{
    public interface IVehicleRepository
    {
        void Add(Vehicle vehicle);
        Task<bool> IsRegistrationNumberUniqueAsync(RegistrationNumber registrationNumber, CancellationToken cancellationToken = default);
        Task<Vehicle?> GetVehicleByIdAsync(Guid id, CancellationToken cancellationToken = default);
    }
}
