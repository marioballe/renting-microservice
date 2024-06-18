using MediatR;
using RentingMicroservice.Application.Commands;
using RentingMicroservice.Application.Interfaces;

namespace RentingMicroservice.Application.Handlers
{
    public class ReturnVehicleCommandHandler : IRequestHandler<ReturnVehicleCommand, bool>
    {
        private readonly IRentingService _rentingService;

        public ReturnVehicleCommandHandler(IRentingService rentingService)
        {
            _rentingService = rentingService;
        }

        public async Task<bool> Handle(ReturnVehicleCommand request, CancellationToken cancellationToken)
        {
            return await _rentingService.ReturnVehicleAsync(request.VehicleId);
        }
    }
}