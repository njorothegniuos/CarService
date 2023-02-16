namespace Domain.DomainEvents
{
   public sealed record MemberShipNumberRegisteredDomainEvent(Guid Id, Guid MemberShipNumberId) : DomainEvent(Id);
}
