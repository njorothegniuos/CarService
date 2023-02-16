using Application.Abstractions.Messaging;
using Domain.Entities;
using Domain.Errors;
using Domain.Repositories;
using Domain.Shared;
using Domain.ValueObjects;

namespace Application.MemberShipNumbers.CreateMemberShipNumber
{
    internal sealed class CreateMemberShipNumberCommandHandler : ICommandHandler<CreateMemberShipNumberCommand, Guid>
    {
        private readonly IMemberRepository _memberRepository;
        private readonly IMemberShipNumberRepository _memberShipNumberRepository;
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateMemberShipNumberCommandHandler(
             IMemberRepository memberRepository, IMemberShipNumberRepository memberShipNumberRepository,
            IVehicleRepository vehicleRepository,
            IUnitOfWork unitOfWork)
        {
            _memberRepository = memberRepository;
            _vehicleRepository = vehicleRepository;
            _memberShipNumberRepository = memberShipNumberRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<Guid>> Handle(CreateMemberShipNumberCommand request, CancellationToken cancellationToken)
        {
            var member = await _memberRepository.GetByIdAsync(request.MemberId, cancellationToken);

            int memberShipNumber = 0;

            if (member is null)
            {
                return Result.Failure<Guid>(new Error(
                "Member.NotFound",
                $"The member with Id {request.MemberId} was not found"));
            }

            var _existingMemberShipNumber = await _memberRepository.GetCountOfRegisteredMemberAsync(cancellationToken);
           
            if (_existingMemberShipNumber<0)
                memberShipNumber = memberShipNumber + 1;
            else
                memberShipNumber = _existingMemberShipNumber + 1;

            string assingedMemberNumber = "0"+ memberShipNumber;

            Result<MemberNumber> memberNumberResult = MemberNumber.Create(assingedMemberNumber);

            var _memberShipNumber = MemberShipNumber.Create(Guid.NewGuid(), member, memberNumberResult.Value);

            _memberShipNumberRepository.Add(_memberShipNumber);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return _memberShipNumber.Id;
        }
    }
}
