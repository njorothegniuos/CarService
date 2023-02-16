using FluentValidation;

namespace Application.MemberShipNumbers.CreateMemberShipNumber
{
    internal class CreateMemberShipNumberCommandValidator : AbstractValidator<CreateMemberShipNumberCommand>
    {
        public CreateMemberShipNumberCommandValidator()
        {
            RuleFor(x => x.MemberId).NotEmpty();
        }
    }
}
