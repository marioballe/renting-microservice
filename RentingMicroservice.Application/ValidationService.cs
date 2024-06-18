using RentingMicroservice.Application.Commands;
using RentingMicroservice.Domain.Entities;
using RentingMicroservice.Domain.Interfaces;
using System;
using System.Collections.Generic;
using RentingMicroservice.Application.Interfaces;

namespace RentingMicroservice.Application
{
    public class ValidationService: IValidationService
    {
        public void ValidateVehicle(AddVehicleCommand command)
        {
            if (command.Year > DateTime.Now.Year) throw new Exception("El año del vehículo no puede ser mayor al año actual");

            if ((DateTime.Now.Year - 5) > command.Year) throw new Exception("El vehículo no puede ser mayor a 5 años");
        }

        public void ValidateRentVehicle(RentVehicleCommand command, List<Vehicle> vehicles)
        {
            if (vehicles.Any(v => v.Id == command.VehicleId && v.IsRented)) throw new Exception("El vehículo no está disponible para alquilar");

            if (vehicles.Any(v => v.UserId == command.UserId)) throw new Exception("El usuario ya tiene un vehículo alquilado");
        }

        public void ValidateReturnVehicle(ReturnVehicleCommand command, List<Vehicle> vehicles)
        {
            if (!vehicles.Any(v => v.Id == command.VehicleId && v.IsRented)) throw new Exception("El vehículo no está alquilado");
        }
    }
}
