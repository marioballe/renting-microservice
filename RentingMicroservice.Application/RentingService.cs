using MediatR;
using RentingMicroservice.Application.Commands;
using RentingMicroservice.Application.Queries;
using RentingMicroservice.Application.DTOs;
using RentingMicroservice.Application.Interfaces;
using RentingMicroservice.Domain.Entities;
using RentingMicroservice.Domain.Interfaces;

namespace RentingMicroservice.Application.Services
{
    public class RentingService : IRentingService
    {
        private readonly IMediator _mediator;
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IValidationService _validationService;
        private readonly List<Vehicle>  _vehicles;

        public RentingService(IMediator mediator, IVehicleRepository vehicleRepository, IValidationService validationService)
        {
            _mediator = mediator;
            _vehicleRepository = vehicleRepository;
            _validationService = validationService;
            _vehicles = _vehicleRepository.GetAllAsync().Result;
        }
        public async Task<bool> AddVehicleAsync(AddVehicleCommand command)
        {
            _validationService.ValidateVehicle(command);

            var vehicle = new Vehicle
            {
                LicensePlateNumber = command.LicensePlateNumber,
                Model = command.Model,
                Year = command.Year,              
            };

            await _vehicleRepository.AddAsync(vehicle);

            return true;
        }
        public async Task<bool> RentVehicleAsync(string vehicleId, string userId)
        {
            var command = new RentVehicleCommand { VehicleId = vehicleId, UserId = userId };

            _validationService.ValidateRentVehicle(command, _vehicles);

            var vehicle = new Vehicle
            {
                Id = vehicleId,
                IsRented = true,
                UserId = userId,
                LicensePlateNumber = _vehicles.Find(v => v.Id == vehicleId).LicensePlateNumber,
                Model = _vehicles.Find(v => v.Id == vehicleId).Model,
                Year = _vehicles.Find(v => v.Id == vehicleId).Year
            };

            await _vehicleRepository.UpdateAsync(vehicle);

            return true;
        }

        public async Task<bool> ReturnVehicleAsync(string vehicleId)
        {
            var command = new ReturnVehicleCommand { VehicleId = vehicleId };
            _validationService.ValidateReturnVehicle(command, _vehicles);

            var vehicle = new Vehicle
            {
                Id = vehicleId,
                IsRented = false,
                UserId = null,
                LicensePlateNumber = _vehicles.Find(v => v.Id == vehicleId).LicensePlateNumber,
                Model = _vehicles.Find(v => v.Id == vehicleId).Model,
                Year = _vehicles.Find(v => v.Id == vehicleId).Year
            };

            await _vehicleRepository.UpdateAsync(vehicle);

            return true;
        }

        public async Task<List<VehicleDto>> ListAvailableVehiclesAsync()
        {
            var query = new ListVehiclesQuery();
            var result =  await _vehicleRepository.GetAllAsync();

            return result.Select(v => new VehicleDto
            {
                Id = v.Id,
                LicensePlateNumber = v.LicensePlateNumber,
                Model = v.Model,
                Year = v.Year.ToString(),
                IsRented = v.IsRented,
                UserId = v.UserId
            }).ToList();
        }
    }

}