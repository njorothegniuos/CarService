namespace Presentation.Contracts.Vehicles
{
    public sealed record RegisterVehicleRequest(Guid memberId, string registrationNumber, string model, int year,
        string vehicleColor, string engineChasisNumber, int capacity, int numberOfPassengers,
        int mileage);
}
