﻿using Application.Abstractions.Messaging;

namespace Application.Vehicles.CreateVehicle
{
    public sealed record CreateVehicleCommand(string RegistrationNumber, string Model, int Year, 
        string VehicleColor, string EngineChasisNumber,int Capacity, int NumberOfPassengers, 
        int Mileage) : ICommand<Guid>;
}
