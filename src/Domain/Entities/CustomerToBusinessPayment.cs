using Domain.DomainEvents;
using Domain.Primitives;

namespace Domain.Entities
{
    public sealed class CustomerToBusinessPayment : AggregateRoot, IAuditableEntity
    {
        private CustomerToBusinessPayment(Guid id, string transactionType, string transID, string transTime, int transAmount, string businessShortCode, string billRefNumber, string invoiceNumber, decimal orgAccountBalance, string thirdPartyTransID, string msisdn, string firstName, string middleName, string lastName)
        : base(id)
        {
            TransactionType = transactionType;
            TransID = transID;
            TransTime = transTime;
            TransAmount = transAmount;
            BusinessShortCode = businessShortCode;
            BillRefNumber = billRefNumber;
            InvoiceNumber = invoiceNumber;
            OrgAccountBalance = orgAccountBalance;
            ThirdPartyTransID = thirdPartyTransID;
            MSISDN = msisdn;
            FirstName = firstName;
            MiddleName = middleName;
            LastName = lastName;
        }

        private CustomerToBusinessPayment()
        {
        }

        public string TransactionType { get; set; }
        public string TransID { get; set; }
        public string TransTime { get; set; }
        public int TransAmount { get; set; }
        public string BusinessShortCode { get; set; }
        public string BillRefNumber { get; set; }
        public string InvoiceNumber { get; set; }
        public decimal OrgAccountBalance { get; set; }
        public string ThirdPartyTransID { get; set; }
        public string MSISDN { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime CreatedOnUtc { get; set; }
        public DateTime? ModifiedOnUtc { get; set; }

        public static CustomerToBusinessPayment Create(Guid id, string transactionType, string transID, string transTime,
            int transAmount, string businessShortCode, string billRefNumber, string invoiceNumber,
            decimal orgAccountBalance, string thirdPartyTransID, string msisdn, string firstName, string middleName,
            string lastName)
        {
            var customerToBusinessPayment = new CustomerToBusinessPayment(
                 id, transactionType, transID, transTime,
                 transAmount, businessShortCode, billRefNumber, invoiceNumber,
                 orgAccountBalance, thirdPartyTransID, msisdn, firstName, middleName,
                 lastName);

            customerToBusinessPayment.RaiseDomainEvent(new CustomerToBusinessPaymentRegisteredDomainEvent(
                Guid.NewGuid(),
                customerToBusinessPayment.Id));

            return customerToBusinessPayment;
        }
    }
}
