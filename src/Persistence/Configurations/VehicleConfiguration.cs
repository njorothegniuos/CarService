using Domain.Entities;
using Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    internal sealed class VehicleConfiguration : IEntityTypeConfiguration<Vehicle>
    {
        public void Configure(EntityTypeBuilder<Vehicle> builder)
        {
            builder.ToTable("Vehicles");

            builder.HasKey(x => new { x.Id });

            builder
           .HasOne<Member>()
           .WithMany()
           .HasForeignKey(x => x.MemberId)
           .OnDelete(DeleteBehavior.Restrict);

            builder
            .Property(x => x.RegistrationNumber)
            .HasConversion(x => x.Value, v => RegistrationNumber.Create(v).Value)
            .HasMaxLength(RegistrationNumber.MaxLength);

            builder
            .Property(x => x.EngineChasisNumber)
            .HasConversion(x => x.Value, v => EngineChasisNumber.Create(v).Value)
            .HasMaxLength(EngineChasisNumber.MaxLength);

            builder
            .Property(x => x.Model)
            .HasConversion(x => x.Value, v => Model.Create(v).Value)
            .HasMaxLength(Model.MaxLength);

            builder
            .Property(x => x.VehicleColor)
            .HasConversion(x => x.Value, v => VehicleColor.Create(v).Value)
            .HasMaxLength(VehicleColor.MaxLength);

        }
    }
}
