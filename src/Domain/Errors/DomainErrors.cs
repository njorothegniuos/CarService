using Domain.Shared;

namespace Domain.Errors
{
    public static class DomainErrors
    {
        public static class RegistrationNumber
        {
            public static readonly Error Empty = new(
                "RegistrationNumber.Empty",
                "Registration number is empty");

            public static readonly Error TooLong = new(
                "RegistrationNumber.TooLong",
                "Registration number is too long");
        }

        public static class VehicleColor
        {
            public static readonly Error Empty = new(
                "VehicleColor.Empty",
                "Vehicle color is empty");

            public static readonly Error TooLong = new(
                "VehicleColor.TooLong",
                "Vehicle color is too long");
        }

        public static class Model
        {
            public static readonly Error Empty = new(
                "Model.Empty",
                "Model is empty");

            public static readonly Error TooLong = new(
                "Model.TooLong",
                "Model is too long");
        }

        public static class EngineChasisNumber
        {
            public static readonly Error Empty = new(
                "EngineChasisNumber.Empty",
                "Engine Chasis number is empty");

            public static readonly Error TooLong = new(
                "EngineChasisNumber.TooLong",
                "Engine Chasis number is too long");
        }
    }
}
