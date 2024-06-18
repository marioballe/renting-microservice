using MediatR;

namespace RentingMicroservice.Application.Commands
{
    public class ReturnVehicleCommand : IRequest<bool>
    {
        public string UserId { get; set; }
        public string VehicleId { get; set; }
    }
}
