﻿namespace Domain.DomainEvents;

public sealed record MemberNameChangedDomainEvent(Guid Id, Guid MemberId) : DomainEvent(Id);
