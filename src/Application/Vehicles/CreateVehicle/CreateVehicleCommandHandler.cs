using Application.Abstractions.Messaging;
using Domain.Entities;
using Domain.Errors;
using Domain.Repositories;
using Domain.Shared;
using Domain.ValueObjects;

namespace Application.Vehicles.CreateVehicle
{
    internal sealed class CreateVehicleCommandHandler : ICommandHandler<CreateVehicleCommand, Guid>
    {
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateVehicleCommandHandler(
            IVehicleRepository vehicleRepository,
            IUnitOfWork unitOfWork)
        {
            _vehicleRepository = vehicleRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<Guid>> Handle(CreateVehicleCommand request, CancellationToken cancellationToken)
        {
            Result<RegistrationNumber> registrationNumberResult = RegistrationNumber.Create(request.RegistrationNumber);
            Result<Model> modelResult = Model.Create(request.Model);
            Result<VehicleColor> vehicleColorResult = VehicleColor.Create(request.VehicleColor);
            Result<EngineChasisNumber> engineChasisNumberResult = EngineChasisNumber.Create(request.EngineChasisNumber);

            var vehicle = Vehicle.Create(Guid.NewGuid(), registrationNumberResult.Value, modelResult.Value, request.Year,
                vehicleColorResult.Value, engineChasisNumberResult.Value
                , request.Capacity, request.NumberOfPassengers, request.Mileage);

            if (!await _vehicleRepository.IsRegistrationNumberUniqueAsync(registrationNumberResult.Value, cancellationToken))
            {
                return Result.Failure<Guid>(DomainErrors.Vehicle.RegistrationNumber.RegistrationNumberAlreadyInUse);
            }

            _vehicleRepository.Add(vehicle);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return vehicle.Id;
        }
    }
}
