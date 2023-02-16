﻿using Domain.Entities;
using Domain.ValueObjects;

namespace Domain.Repositories;

public interface IMemberRepository
{
    Task<Member?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<int> GetCountOfRegisteredMemberAsync(CancellationToken cancellationToken = default);
    Task<Member?> GetByEmailAsync(Email email, CancellationToken cancellationToken = default);

    Task<bool> IsEmailUniqueAsync(Email email, CancellationToken cancellationToken = default);

    void Add(Member member);

    void Update(Member member);
}
