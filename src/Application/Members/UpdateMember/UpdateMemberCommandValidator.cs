﻿using FluentValidation;
using Domain.ValueObjects;

namespace Application.Members.UpdateMember;
internal class UpdateMemberCommandValidator : AbstractValidator<UpdateMemberCommand>
{
    public UpdateMemberCommandValidator()
    {
        RuleFor(x => x.MemberId).NotEmpty();

        RuleFor(x => x.FirstName).NotEmpty().MaximumLength(FirstName.MaxLength);

        RuleFor(x => x.LastName).NotEmpty().MaximumLength(LastName.MaxLength);
    }
}