using RentingMicroservice.Application.Commands;
using RentingMicroservice.Application.DTOs;

namespace RentingMicroservice.Application.Interfaces
{
    public interface IRentingService
    {
        Task<bool> AddVehicleAsync(AddVehicleCommand command);
        Task<bool> RentVehicleAsync(string vehicleId, string userId);
        Task<bool> ReturnVehicleAsync(string vehicleId);
        Task<List<VehicleDto>> ListAvailableVehiclesAsync();
    }
}
