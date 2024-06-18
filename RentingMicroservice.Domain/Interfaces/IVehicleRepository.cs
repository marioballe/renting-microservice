using RentingMicroservice.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RentingMicroservice.Domain.Interfaces
{
    public interface IVehicleRepository
    {
        Task<List<Vehicle>> GetAllAsync();
        Task AddAsync(Vehicle vehicle);
        Task UpdateAsync(Vehicle vehicle);
        Task DeleteAsync(string id);
    }
}