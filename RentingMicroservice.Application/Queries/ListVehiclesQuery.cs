using MediatR;
using RentingMicroservice.Application.DTOs;

namespace RentingMicroservice.Application.Queries
{
    public class ListVehiclesQuery : IRequest<List<VehicleDto>>
    {
    }
}