namespace Domain.DomainEvents
{
    public sealed record CustomerToBusinessPaymentRegisteredDomainEvent(Guid Id, Guid CustomerToBusinessPaymentId) : DomainEvent(Id);
}
