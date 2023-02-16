using Domain.Entities;

namespace Domain.Repositories
{
    public interface ICustomerToBusinessPaymentRepository
    {
        void Add(CustomerToBusinessPayment customerToBusinessPayment);
    }
}
