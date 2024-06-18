using MediatR;
using RentingMicroservice.Application.Commands;
using RentingMicroservice.Application.Interfaces;

namespace RentingMicroservice.Application.Handlers
{
    public class RentVehicleCommandHandler : IRequestHandler<RentVehicleCommand, bool>
    {
        private readonly IRentingService _rentingService;

        public RentVehicleCommandHandler(IRentingService rentingService)
        {
            _rentingService = rentingService;
        }

        public async Task<bool> Handle(RentVehicleCommand request, CancellationToken cancellationToken)
        {
            return await _rentingService.RentVehicleAsync(request.VehicleId, request.UserId);
        }
    }
}