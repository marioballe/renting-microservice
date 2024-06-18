using RentingMicroservice.Application.Commands;
using RentingMicroservice.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentingMicroservice.Application.Interfaces
{
    public interface IValidationService
    {
        void ValidateVehicle(AddVehicleCommand command);

        void ValidateRentVehicle(RentVehicleCommand command, List<Vehicle> vehicles);

        void ValidateReturnVehicle(ReturnVehicleCommand command, List<Vehicle> vehicles);
    }
}
