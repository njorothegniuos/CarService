using Domain.Shared;
using Presentation.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Presentation.Contracts.Vehicles;
using Application.Vehicles.CreateVehicle;

namespace Presentation.Controllers;

[Route("api/vehicle")]
public sealed class VehicleController : ApiController
{
    public VehicleController(ISender sender)
        : base(sender)
    {
    }

    [HttpPost]
    public async Task<IActionResult> RegisterMember(
       [FromBody] RegisterVehicleRequest request,
       CancellationToken cancellationToken)
    {
        var command = new CreateVehicleCommand(request.memberId,
            request.registrationNumber,request.model,request.year,request.vehicleColor,
            request.engineChasisNumber, request.capacity, request.numberOfPassengers, request.mileage);

        Result<Guid> result = await Sender.Send(command, cancellationToken);

        if (result.IsFailure)
        {
            return HandleFailure(result);
        }

        return CreatedAtAction(
            nameof(RegisterMember),
            new { id = result.Value },
            result.Value);
    }
}
