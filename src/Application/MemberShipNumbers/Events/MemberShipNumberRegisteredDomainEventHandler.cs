using Application.Abstractions;
using Application.Abstractions.Messaging;
using Domain.DomainEvents;
using Domain.Entities;
using Domain.Repositories;

namespace Application.Members.Events;

internal sealed class MemberShipNumberRegisteredDomainEventHandler
     : IDomainEventHandler<MemberShipNumberRegisteredDomainEvent>
{
    private readonly IMemberShipNumberRepository _memberShipNumberRepository;
    private readonly IEmailService _emailService;

    public MemberShipNumberRegisteredDomainEventHandler(
        IMemberShipNumberRepository memberShipNumberRepository,
        IEmailService emailService)
    {
        _memberShipNumberRepository = memberShipNumberRepository;
        _emailService = emailService;
    }

    public async Task Handle(
        MemberShipNumberRegisteredDomainEvent notification,
        CancellationToken cancellationToken)
    {
        MemberShipNumber? member = await _memberShipNumberRepository.GetMemberShipNumberByIdAsync(
            notification.MemberShipNumberId,
            cancellationToken);

        if (member is null)
        {
            return;
        }
    }
}
