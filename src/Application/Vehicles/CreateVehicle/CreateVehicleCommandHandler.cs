using Application.Abstractions.Messaging;
using Application.Members.GetMemberById;
using Domain.Entities;
using Domain.Errors;
using Domain.Repositories;
using Domain.Shared;
using Domain.ValueObjects;
using MediatR;

namespace Application.Vehicles.CreateVehicle
{
    internal sealed class CreateVehicleCommandHandler : ICommandHandler<CreateVehicleCommand, Guid>
    {
        private readonly IMemberRepository _memberRepository;
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateVehicleCommandHandler(
             IMemberRepository memberRepository,
            IVehicleRepository vehicleRepository,
            IUnitOfWork unitOfWork)
        {
            _memberRepository = memberRepository;
            _vehicleRepository = vehicleRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<Guid>> Handle(CreateVehicleCommand request, CancellationToken cancellationToken)
        {
            var member = await _memberRepository.GetByIdAsync(request.MemberId, cancellationToken);

            if (member is null)
            {
                return Result.Failure<Guid>(new Error(
                "Member.NotFound",
                $"The member with Id {request.MemberId} was not found"));
            }

            Result<RegistrationNumber> registrationNumberResult = RegistrationNumber.Create(request.RegistrationNumber);
            Result<Model> modelResult = Model.Create(request.Model);
            Result<VehicleColor> vehicleColorResult = VehicleColor.Create(request.VehicleColor);
            Result<EngineChasisNumber> engineChasisNumberResult = EngineChasisNumber.Create(request.EngineChasisNumber);

            var vehicle = Vehicle.Create(Guid.NewGuid(), member, registrationNumberResult.Value, modelResult.Value, request.Year,
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
