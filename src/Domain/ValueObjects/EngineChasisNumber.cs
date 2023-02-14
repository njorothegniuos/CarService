using Domain.Errors;
using Domain.Primitives;
using Domain.Shared;

namespace Domain.ValueObjects
{
    public sealed class EngineChasisNumber : ValueObject
    {
        public const int MaxLength = 20;

        private EngineChasisNumber(string value)
        {
            Value = value;
        }

        public string Value { get; }

        public static Result<EngineChasisNumber> Create(string engineChasisNumber)
        {
            if (string.IsNullOrWhiteSpace(engineChasisNumber))
            {
                return Result.Failure<EngineChasisNumber>(DomainErrors.EngineChasisNumber.Empty);
            }

            if (engineChasisNumber.Length > MaxLength)
            {
                return Result.Failure<EngineChasisNumber>(DomainErrors.EngineChasisNumber.TooLong);
            }

            return new EngineChasisNumber(engineChasisNumber);
        }

        public override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }
    }
}
