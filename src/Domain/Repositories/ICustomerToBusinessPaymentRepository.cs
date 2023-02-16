using Domain.Entities;

namespace Domain.Repositories
{
    public interface ICustomerToBusinessPaymentRepository
    {
        Task<CustomerToBusinessPayment?> GetCustomerToBusinessPaymentByIdAsync(Guid id, CancellationToken cancellationToken = default);
        void Add(CustomerToBusinessPayment customerToBusinessPayment);
    }
}
