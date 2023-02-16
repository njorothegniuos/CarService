using Domain.Shared;

namespace Domain.Errors
{
    public static class DomainErrors
    {
        public static class Vehicle
        {
            public static class RegistrationNumber
            {
                public static readonly Error RegistrationNumberAlreadyInUse = new(
                "Vehicle.RegistrationNumberAlreadyInUse",
                "The specified registration number is already in use");

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
        public static class Member
        {
            public static readonly Error EmailAlreadyInUse = new(
                "Member.EmailAlreadyInUse",
                "The specified email is already in use");

            public static readonly Func<Guid, Error> NotFound = id => new Error(
                "Member.NotFound",
                $"The member with the identifier {id} was not found.");
        }
        public static class Email
        {
            public static readonly Error Empty = new(
                "Email.Empty",
                "Email is empty");

            public static readonly Error TooLong = new(
                "Email.TooLong",
                "Email is too long");

            public static readonly Error InvalidFormat = new(
                "Email.InvalidFormat",
                "Email format is invalid");
        }

        public static class FirstName
        {
            public static readonly Error Empty = new(
                "FirstName.Empty",
                "First name is empty");

            public static readonly Error TooLong = new(
                "LastName.TooLong",
                "FirstName name is too long");
        }

        public static class LastName
        {
            public static readonly Error Empty = new(
                "LastName.Empty",
                "Last name is empty");

            public static readonly Error TooLong = new(
                "LastName.TooLong",
                "Last name is too long");
        }
    }
}
