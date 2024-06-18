using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using RentingMicroservice.Domain;
using RentingMicroservice.Domain.Entities;
using RentingMicroservice.Domain.Interfaces;

namespace RentingMicroservice.Infrastructure.Repository
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly IMongoCollection<Vehicle> _collection;

        public VehicleRepository(MongoDbContext dbContext)
        {
            _collection = dbContext.GetCollection<Vehicle>("Vehicles");
        }

        public async Task<List<Vehicle>> GetAllAsync()
        {
            return await _collection.Find(_ => true).ToListAsync();
        }

        public async Task AddAsync(Vehicle vehicle)
        {
            await _collection.InsertOneAsync(vehicle);
        }

        public async Task UpdateAsync(Vehicle vehicle)
        {
            await _collection.ReplaceOneAsync(v => v.Id == vehicle.Id, vehicle);
        }

        public async Task DeleteAsync(string id)
        {
            await _collection.DeleteOneAsync(vehicle => vehicle.Id == id);
        }
    }
}