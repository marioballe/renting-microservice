using MediatR;
using RentingMicroservice.Application.Commands;
using RentingMicroservice.Application.Interfaces;

namespace RentingMicroservice.Application.Handlers
{
    public class AddVehicleCommandHandler : IRequestHandler<AddVehicleCommand, bool>
    {
        private readonly IRentingService _rentingService;

        public AddVehicleCommandHandler(IRentingService rentingService)
        {
            _rentingService = rentingService;
        }

        public async Task<bool> Handle(AddVehicleCommand request, CancellationToken cancellationToken)
        {
            return await _rentingService.AddVehicleAsync(request);
        }
    }
}