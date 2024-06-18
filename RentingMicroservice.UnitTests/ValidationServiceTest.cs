using RentingMicroservice.Application;
using RentingMicroservice.Application.Commands;
using RentingMicroservice.Domain.Entities;


namespace RentingMicroservice.UnitTests
{
    [TestFixture]
    public class ValidationServiceTests
    {
        private ValidationService _validationService;
        private string _vehicleId = "1";
        private string _userId = "1";

        [SetUp]
        public void Setup()
        {
            _validationService = new ValidationService();

        }

        [Test]
        public void ValidateVehicle_WithFutureYear_ThrowsException()
        {
            var command = new AddVehicleCommand { Year = DateTime.Now.Year + 1 };
            Assert.Throws<Exception>(() => _validationService.ValidateVehicle(command));
        }

        [Test]
        public void ValidateVehicle_WithOldVehicle_ThrowsException()
        {
            var command = new AddVehicleCommand { Year = DateTime.Now.Year - 6 };
            Assert.Throws<Exception>(() => _validationService.ValidateVehicle(command));
        }

        [Test]
        public void ValidateRentVehicle_WithUserAlreadyRenting_ThrowsException()
        {
            var command = new RentVehicleCommand { VehicleId = _vehicleId, UserId = _userId };
            var vehicles = new List<Vehicle> { new Vehicle { Id = _vehicleId, UserId = _userId } };
            Assert.Throws<Exception>(() => _validationService.ValidateRentVehicle(command, vehicles));
        }

        [Test]
        public void ValidateReturnVehicle_WithNotRentedVehicle_ThrowsException()
        {
            var command = new ReturnVehicleCommand { VehicleId = _vehicleId };
            var vehicles = new List<Vehicle> { new Vehicle { Id = _vehicleId, IsRented = false } };
            Assert.Throws<Exception>(() => _validationService.ValidateReturnVehicle(command, vehicles));
        }
    }
}