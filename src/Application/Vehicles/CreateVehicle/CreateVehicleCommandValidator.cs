using Domain.ValueObjects;
using FluentValidation;

namespace Application.Vehicles.CreateVehicle
{
    internal class CreateVehicleCommandValidator : AbstractValidator<CreateVehicleCommand>
    {
        public CreateVehicleCommandValidator()
        {
            RuleFor(x => x.EngineChasisNumber).NotEmpty().MaximumLength(EngineChasisNumber.MaxLength);

            RuleFor(x => x.VehicleColor).NotEmpty().MaximumLength(VehicleColor.MaxLength);

            RuleFor(x => x.Model).NotEmpty().MaximumLength(Model.MaxLength);

            RuleFor(x => x.RegistrationNumber).NotEmpty().MaximumLength(RegistrationNumber.MaxLength);
        }
    }
}
