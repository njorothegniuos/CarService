using Domain.Errors;
using Domain.Primitives;
using Domain.Shared;

namespace Domain.ValueObjects
{
    public sealed class MemberNumber : ValueObject
    {
        public const int MaxLength = 20;

        private MemberNumber(string value)
        {
            Value = value;
        }

        public string Value { get; }

        public static Result<MemberNumber> Create(string MemberNumber)
        {
            if (string.IsNullOrWhiteSpace(MemberNumber))
            {
                return Result.Failure<MemberNumber>(DomainErrors.MemberNumber.Empty);
            }

            if (MemberNumber.Length > MaxLength)
            {
                return Result.Failure<MemberNumber>(DomainErrors.MemberNumber.TooLong);
            }

            return new MemberNumber(MemberNumber);
        }

        public override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }
    }
}
