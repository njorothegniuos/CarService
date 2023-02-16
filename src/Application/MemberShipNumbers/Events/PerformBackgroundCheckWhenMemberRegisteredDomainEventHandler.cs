using Application.Abstractions.Messaging;
using Domain.DomainEvents;

namespace Application.Members.Events;

internal sealed class PerformBackgroundCheckWhenMemberShipNumberDomainEventHandler
    : IDomainEventHandler<MemberShipNumberRegisteredDomainEvent>
{
    public Task Handle(
        MemberShipNumberRegisteredDomainEvent notification,
        CancellationToken cancellationToken) =>
        Task.CompletedTask;
}
