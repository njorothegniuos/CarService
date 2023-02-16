using Application.Abstractions.Messaging;
using Domain.Entities;
using Domain.Repositories;
using Domain.Shared;

namespace Application.CustomerToBusinessPayments
{
    internal sealed class CreateCustomerToBusinessPaymentCommandHandler : ICommandHandler<CreateCustomerToBusinessPaymentCommand, Guid>
    {      
        private readonly ICustomerToBusinessPaymentRepository _customerToBusinessPaymentRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateCustomerToBusinessPaymentCommandHandler(ICustomerToBusinessPaymentRepository customerToBusinessPaymentRepository
            , IUnitOfWork unitOfWork)
        {
            _customerToBusinessPaymentRepository = customerToBusinessPaymentRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<Guid>> Handle(CreateCustomerToBusinessPaymentCommand request, CancellationToken cancellationToken)
        {        
            var customerToBusinessPayment = CustomerToBusinessPayment.Create(Guid.NewGuid(), request.TransactionType, request.TransID,
                request.TransTime, request.TransAmount, request.BusinessShortCode, request.BillRefNumber, request.InvoiceNumber,
                request.OrgAccountBalance, request.ThirdPartyTransID, request.Msisdn, request.FirstName, request.MiddleName, request.LastName);

            _customerToBusinessPaymentRepository.Add(customerToBusinessPayment);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return customerToBusinessPayment.Id;
        }
    }
}
