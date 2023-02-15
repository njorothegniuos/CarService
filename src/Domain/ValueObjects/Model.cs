using Domain.Errors;
using Domain.Primitives;
using Domain.Shared;

namespace Domain.ValueObjects
{
    public sealed class Model : ValueObject
    {
        public const int MaxLength = 20;

        private Model(string value)
        {
            Value = value;
        }

        public string Value { get; }

        public static Result<Model> Create(string model)
        {
            if (string.IsNullOrWhiteSpace(model))
            {
                return Result.Failure<Model>(DomainErrors.Vehicle.Model.Empty);
            }

            if (model.Length > MaxLength)
            {
                return Result.Failure<Model>(DomainErrors.Vehicle.Model.TooLong);
            }

            return new Model(model);
        }

        public override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }
    }
}
