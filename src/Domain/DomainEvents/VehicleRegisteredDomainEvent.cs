namespace Domain.DomainEvents
{
    public sealed record VehicleRegisteredDomainEvent(Guid Id, Guid MemberId) : DomainEvent(Id);
}
