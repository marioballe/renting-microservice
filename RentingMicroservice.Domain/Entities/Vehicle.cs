using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace RentingMicroservice.Domain.Entities
{
    public class Vehicle
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }  = String.Empty;
        public string LicensePlateNumber { get; set; } = String.Empty;
        public string Model { get; set; } = String.Empty;
        public int Year { get; set; }
        [BsonElement("Rented")]
        public bool IsRented { get; set; }
        [BsonElement("Renter")]
        public string? UserId { get; set; }

    }
}
