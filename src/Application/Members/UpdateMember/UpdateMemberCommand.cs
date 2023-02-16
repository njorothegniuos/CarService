using Application.Abstractions.Messaging;

namespace Application.Members.UpdateMember;

public sealed record UpdateMemberCommand(Guid MemberId, string FirstName, string LastName) : ICommand;
