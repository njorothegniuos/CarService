using Application.Abstractions.Messaging;
using Domain.DomainEvents;

namespace Application.Vehicles.Events
{
    internal sealed class PerformBackgroundCheckWhenVehicleRegisteredDomainEventHandler
    : IDomainEventHandler<VehicleRegisteredDomainEvent>
    {
        public Task Handle(
            VehicleRegisteredDomainEvent notification,
            CancellationToken cancellationToken) =>
            Task.CompletedTask;
    }
}
