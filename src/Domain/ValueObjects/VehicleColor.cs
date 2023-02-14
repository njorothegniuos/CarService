using Domain.Errors;
using Domain.Primitives;
using Domain.Shared;

namespace Domain.ValueObjects
{
    public sealed class VehicleColor : ValueObject
    {
        public const int MaxLength = 20;

        private VehicleColor(string value)
        {
            Value = value;
        }

        public string Value { get; }

        public static Result<VehicleColor> Create(string vehicleColor)
        {
            if (string.IsNullOrWhiteSpace(vehicleColor))
            {
                return Result.Failure<VehicleColor>(DomainErrors.VehicleColor.Empty);
            }

            if (vehicleColor.Length > MaxLength)
            {
                return Result.Failure<VehicleColor>(DomainErrors.VehicleColor.TooLong);
            }

            return new VehicleColor(vehicleColor);
        }

        public override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }
    }
}
