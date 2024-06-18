using MediatR;

namespace RentingMicroservice.Application.Commands
{
    public class RentVehicleCommand : IRequest<bool>
    {
        public string UserId { get; set; }
        public string VehicleId { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
    }
}
