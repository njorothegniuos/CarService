using Application.Abstractions.Messaging;

namespace Application.Members.GetMemberById;

public sealed record GetMemberByIdQuery(Guid MemberId) : IQuery<MemberResponse>;