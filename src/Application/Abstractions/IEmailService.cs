using Domain.Entities;

namespace Application.Abstractions;

public interface IEmailService
{
    Task SendNewRegisteredVehicleEmailAsync(Vehicle vehicle, CancellationToken cancellationToken = default);
    Task SendWelcomeEmailAsync(Member member, CancellationToken cancellationToken = default);

    Task SendMemberShipFeeEmailAsync(Member member, CancellationToken cancellationToken = default);
}
