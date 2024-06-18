using MediatR;
using RentingMicroservice.Application.DTOs;
using RentingMicroservice.Application.Queries;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using RentingMicroservice.Application.Services;
using RentingMicroservice.Application.Interfaces;

namespace RentingMicroservice.Application.Handlers
{
    public class ListVehiclesQueryHandler : IRequestHandler<ListVehiclesQuery, List<VehicleDto>>
    {
        private readonly IRentingService _rentingService;

        public ListVehiclesQueryHandler(IRentingService rentingService)
        {
            _rentingService = rentingService;
        }

        public async Task<List<VehicleDto>> Handle(ListVehiclesQuery request, CancellationToken cancellationToken)
        {
            return await _rentingService.ListAvailableVehiclesAsync();
        }
    }
}