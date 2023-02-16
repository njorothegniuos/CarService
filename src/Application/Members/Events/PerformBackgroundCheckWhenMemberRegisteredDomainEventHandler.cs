using Application.Abstractions.Messaging;
using Domain.DomainEvents;

namespace Application.Members.Events;

internal sealed class PerformBackgroundCheckWhenMemberRegisteredDomainEventHandler
    : IDomainEventHandler<MemberRegisteredDomainEvent>
{
    public Task Handle(
        MemberRegisteredDomainEvent notification,
        CancellationToken cancellationToken) =>
        Task.CompletedTask;
}
