using Application.Abstractions;
using Application.Abstractions.Messaging;
using Domain.DomainEvents;
using Domain.Entities;
using Domain.Repositories;

namespace Application.Vehicles.Events
{
    internal sealed class VehicleRegisteredDomainEventHandler
     : IDomainEventHandler<VehicleRegisteredDomainEvent>
    {
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IEmailService _emailService;

        public VehicleRegisteredDomainEventHandler(
            IVehicleRepository vehicleRepository,
            IEmailService emailService)
        {
            _vehicleRepository = vehicleRepository;
            _emailService = emailService;
        }

        public async Task Handle(
            VehicleRegisteredDomainEvent notification,
            CancellationToken cancellationToken)
        {
            Vehicle? vehicle = await _vehicleRepository.GetVehicleByIdAsync(
                notification.Id,
                cancellationToken);

            if (vehicle is null)
            {
                return;
            }

            await _emailService.SendNewRegisteredVehicleEmailAsync(vehicle, cancellationToken);
        }
    }
}
