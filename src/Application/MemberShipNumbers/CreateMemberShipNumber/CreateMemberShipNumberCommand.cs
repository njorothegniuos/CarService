using Application.Abstractions.Messaging;

namespace Application.MemberShipNumbers.CreateMemberShipNumber
{
    public sealed record CreateMemberShipNumberCommand(Guid MemberId) : ICommand<Guid>;
}
