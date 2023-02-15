using Domain.Entities;

namespace Application.Abstractions;

public interface IEmailService
{
    Task SendNewRegisteredVehicleEmailAsync(Vehicle vehicle, CancellationToken cancellationToken = default);
}
