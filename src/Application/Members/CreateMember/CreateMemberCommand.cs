using Application.Abstractions.Messaging;

namespace Application.Members.CreateMember;

public sealed record CreateMemberCommand(
    string Email,
    string FirstName,
    string LastName) : ICommand<Guid>;
