using Application.Abstractions.Messaging;

namespace Application.Vehicles.CreateVehicle
{
    public sealed record CreateVehicleCommand(
    string RegistrationNumber, string Model, int year, string VehicleColor, string EngineChasisNumber,
            int capacity, int numberOfPassengers, int mileage) : ICommand<Guid>;
}
