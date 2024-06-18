using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace RentingMicroservice.Api.Models
{
    public class RentingDatabaseSettings
    {
        public string ConnectionString { get; set; } = null!;

        public string DatabaseName { get; set; } = null!;

        public string VehiclesCollectionName { get; set; } = null!;
    }
}
