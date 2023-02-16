using Domain.DomainEvents;
using Domain.Primitives;
using Domain.ValueObjects;

namespace Domain.Entities
{
    public sealed class MemberShipNumber : AggregateRoot, IAuditableEntity
    {
        private MemberShipNumber(Guid id, Member member, MemberNumber memberShipNumber)
           : base(id)
        {
            MemberId = member.Id;
            memberShipNumber = memberShipNumber;
        }

        private MemberShipNumber()
        {
        }

        public Guid MemberId { get; private set; }
        public byte RecordStatus { get; private set; }
        public MemberNumber MemberNumber { get; set; }
        public DateTime CreatedOnUtc { get; set; }
        public DateTime? ModifiedOnUtc { get; set; }

        public static MemberShipNumber Create(Guid id, Member member, MemberNumber memberShipNumber)
        {
            var vehicle = new MemberShipNumber(
                id,
                member,
                memberShipNumber);

            vehicle.RaiseDomainEvent(new MemberShipNumberRegisteredDomainEvent(Guid.NewGuid(), vehicle.Id));

            return vehicle;
        }

        public void ChangeMemberShipStatus(byte recordStatus)
        {
            RecordStatus = recordStatus;
        }
    }
}
