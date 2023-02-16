using Application.Abstractions.Messaging;
using Domain.DomainEvents;

namespace Application.Members.Events;

internal sealed class PerformBackgroundCheckWhenCustomerToBusinessPaymentRegisteredDomainEventHandler
    : IDomainEventHandler<CustomerToBusinessPaymentRegisteredDomainEvent>
{
    public Task Handle(
        CustomerToBusinessPaymentRegisteredDomainEvent notification,
        CancellationToken cancellationToken) =>
        Task.CompletedTask;
}
