using Application.Abstractions;
using Domain.Entities;

namespace Infrastructure.Services;

internal sealed class EmailService : IEmailService
{
    public Task SendWelcomeEmailAsync(Member member, CancellationToken cancellationToken = default) =>
       Task.CompletedTask;
    public Task SendNewRegisteredVehicleEmailAsync(Vehicle vehicle, CancellationToken cancellationToken = default) =>
        Task.CompletedTask;

    public Task SendMemberShipFeeEmailAsync(Member member, CancellationToken cancellationToken = default) =>
        Task.CompletedTask;
}
