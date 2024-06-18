using NUnit.Framework;
using RentingMicroservice.Application;
using RentingMicroservice.Application.Commands;
using RentingMicroservice.Domain.Entities;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using RentingMicroservice.Application.Interfaces;
using RentingMicroservice.Application.Services;
using MediatR;
using RentingMicroservice.Domain.Interfaces;

namespace RentingMicroservice.UnitTests
{
    [TestFixture]
public class RentingServiceTests
{
    private RentingService _rentingService;
    private Mock<IValidationService> _mockValidationService;
    private Mock<IMediator> _mockMediator;
    private Mock<IVehicleRepository> _mockVehicleRepository;
    private string _vehicleId = "1";
    private string _userId = "1";

    [SetUp]
    public void Setup()
    {
        _mockMediator = new Mock<IMediator>();
        _mockVehicleRepository = new Mock<IVehicleRepository>();
        _mockValidationService = new Mock<IValidationService>();
        _rentingService = new RentingService(_mockMediator.Object, _mockVehicleRepository.Object, _mockValidationService.Object);

    }

    [Test]
    public async Task AddVehicle_WithValidVehicle_AddsVehicle()
    {
        var command = new AddVehicleCommand { Year = 2022, Model = "Ford", LicensePlateNumber = "B-2485-TK" };
        await _rentingService.AddVehicleAsync(command);

        _mockValidationService.Verify(v => v.ValidateVehicle(command), Times.Once);
    }
    }
}