using Application.Abstractions;
using Application.Abstractions.Messaging;
using Domain.DomainEvents;
using Domain.Entities;
using Domain.Repositories;

namespace Application.Members.Events;

internal sealed class CustomerToBusinessPaymentRegisteredDomainEventHandler
     : IDomainEventHandler<CustomerToBusinessPaymentRegisteredDomainEvent>
{
    private readonly ICustomerToBusinessPaymentRepository _customerToBusinessPaymentRepository;
    private readonly IEmailService _emailService;

    public CustomerToBusinessPaymentRegisteredDomainEventHandler(
        ICustomerToBusinessPaymentRepository customerToBusinessPaymentRepository,
        IEmailService emailService)
    {
        _customerToBusinessPaymentRepository = customerToBusinessPaymentRepository;
        _emailService = emailService;
    }

    public async Task Handle(
        CustomerToBusinessPaymentRegisteredDomainEvent notification,
        CancellationToken cancellationToken)
    {
        CustomerToBusinessPayment? customerToBusinessPayment = await _customerToBusinessPaymentRepository.GetCustomerToBusinessPaymentByIdAsync(
            notification.CustomerToBusinessPaymentId,
            cancellationToken);

        if (customerToBusinessPayment is null)
        {
            return;
        }

        await _emailService.SendPaymentNotificationEmailAsync(customerToBusinessPayment, cancellationToken);
    }
}
