using MediatR;
using RentingMicroservice.Application.DTOs;

namespace RentingMicroservice.Application.Commands
{
    public class AddVehicleCommand : IRequest<bool>
    {
        public string LicensePlateNumber { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
    }
}