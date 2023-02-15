using Application.Abstractions;
using Domain.Entities;

namespace Infrastructure.Services;

internal sealed class EmailService : IEmailService
{
    public Task SendNewRegisteredVehicleEmailAsync(Vehicle vehicle, CancellationToken cancellationToken = default) =>
        Task.CompletedTask;
}
