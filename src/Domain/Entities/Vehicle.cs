using Domain.DomainEvents;
using Domain.Primitives;
using Domain.ValueObjects;

namespace Domain.Entities
{
    public sealed class Vehicle : AggregateRoot, IAuditableEntity
    {
        private Vehicle(Guid id, Member member, RegistrationNumber registrationNumber,Model model, int year, VehicleColor vehicleColor,             EngineChasisNumber engineChasisNumber,
            int capacity,int numberOfPassengers, int mileage)
            : base(id)
        {
            MemberId = member.Id;
            RegistrationNumber = registrationNumber;
            Capacity = capacity;
            NumberOfPassengers = numberOfPassengers;
            Mileage = mileage;
        }

        private Vehicle()
        {
        }
        public Guid MemberId { get; private set; }
        public RegistrationNumber RegistrationNumber { get; set; }

        public Model Model { get; set; }

        public int Year { get; set; }
        public VehicleColor VehicleColor { get; set; }
        public EngineChasisNumber EngineChasisNumber { get; set; }
        public int Capacity { get; set; }
        public int NumberOfPassengers { get; set; }
        public int Mileage { get; set; }
        public DateTime CreatedOnUtc { get; set; }

        public DateTime? ModifiedOnUtc { get; set; }

        public static Vehicle Create(
            Guid id, Member member, RegistrationNumber registrationNumber, Model model, int year, VehicleColor vehicleColor,  
            EngineChasisNumber engineChasisNumber,
            int capacity, int numberOfPassengers, int mileage)
        {
            var vehicle = new Vehicle(
                id,
                member,
                registrationNumber,
                model,
                year, vehicleColor,
                engineChasisNumber, capacity, numberOfPassengers, mileage);

            vehicle.RaiseDomainEvent(new VehicleRegisteredDomainEvent(Guid.NewGuid(), vehicle.Id));

            return vehicle;
        }

        public void ChangeMileage(int mileage)
        {
            Mileage = mileage;
        }
    }

}
