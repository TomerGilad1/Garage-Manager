using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.Logic
{
    public class VehicleFactory
    {
        public static Vehicle CreateVehicle(eVehicleType i_VehicleType)
        {
            object newVehicle = new object();

            switch (i_VehicleType)
            {
                case eVehicleType.Truck:
                    newVehicle = new Truck();
                    break;
                case eVehicleType.ElectricCar:
                    newVehicle = new ElectricCar();
                    break;
                case eVehicleType.ElectricMotorcycle:
                    newVehicle = new ElectricMotorcycle();
                    break;
                case eVehicleType.FuelBasedCar:
                    newVehicle = new FuelBasedCar();
                    break;
                case eVehicleType.FuelBasedMotorcycle:
                    newVehicle = new FuelBasedMotorcycle();
                    break;
            }

            return newVehicle as Vehicle;
        }
    }
}