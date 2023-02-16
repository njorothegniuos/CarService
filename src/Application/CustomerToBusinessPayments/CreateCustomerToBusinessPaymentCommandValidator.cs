using FluentValidation;

namespace Application.CustomerToBusinessPayments
{
    internal class CreateCustomerToBusinessPaymentCommandValidator : AbstractValidator<CreateCustomerToBusinessPaymentCommand>
    {
        public CreateCustomerToBusinessPaymentCommandValidator()
        {
            RuleFor(x => x.BillRefNumber).NotEmpty();

            RuleFor(x => x.TransID).NotEmpty();

            RuleFor(x => x.Msisdn).NotEmpty();
        }
    }
}
