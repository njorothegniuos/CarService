using Application.Abstractions.Messaging;

namespace Application.CustomerToBusinessPayments
{
    public sealed record CreateCustomerToBusinessPaymentCommand(string TransactionType, string TransID, string TransTime, int TransAmount, 
        string BusinessShortCode, string BillRefNumber, string InvoiceNumber, decimal OrgAccountBalance, string ThirdPartyTransID,
        string Msisdn, string FirstName, string MiddleName, string LastName) : ICommand<Guid>;
}
