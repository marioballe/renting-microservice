

namespace RentingMicroservice.Application.DTOs
{
    public class VehicleDto
    {
        public string Id { get; set; }
        public string LicensePlateNumber { get; set; }
        public string Model { get; set; }
        public string Year { get; set; }
        public bool IsRented { get; set; } = false;
        public string? UserId { get; set; } = null;
    }
}
