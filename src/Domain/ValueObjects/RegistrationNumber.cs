using Domain.Errors;
using Domain.Primitives;
using Domain.Shared;

namespace Domain.ValueObjects
{
    public sealed class RegistrationNumber : ValueObject
    {
        public const int MaxLength = 20;

        private RegistrationNumber(string value)
        {
            Value = value;
        }

        public string Value { get; }

        public static Result<RegistrationNumber> Create(string registrationNumber)
        {
            if (string.IsNullOrWhiteSpace(registrationNumber))
            {
                return Result.Failure<RegistrationNumber>(DomainErrors.RegistrationNumber.Empty);
            }

            if (registrationNumber.Length > MaxLength)
            {
                return Result.Failure<RegistrationNumber>(DomainErrors.RegistrationNumber.TooLong);
            }

            return new RegistrationNumber(registrationNumber);
        }

        public override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }
    }
}
