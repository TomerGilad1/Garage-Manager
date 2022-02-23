using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;

namespace Ex03.Logic
{
    public class GarageManager
    {
        private readonly List<CustomerData> m_CustomersDataList;
        private readonly List<Vehicle> m_VehiclesList;

        public GarageManager()
        {
            m_CustomersDataList = new List<CustomerData>();
            m_VehiclesList = new List<Vehicle>();
        }

        public void AddNewVehicleToTheGarage(string i_RegistrationNumber, string i_OwnerName, string i_OwnerPhone, Vehicle i_Vehicle)
        {
            if (!VehicleAlreadyInGarage(i_RegistrationNumber))
            {
                m_CustomersDataList.Add(new CustomerData(i_OwnerName, i_OwnerPhone, i_Vehicle));
                m_VehiclesList.Add(i_Vehicle);
            }
            else
            {
                m_VehiclesList.Add(i_Vehicle);
            }
        }

        public string AllVehicleData(string o_RegistrationNumber)
        {
            CustomerData customerWanted = FineCustomerData(o_RegistrationNumber);
            return customerWanted.ToString();
        }

        public bool VehicleAlreadyInGarage(string i_RegistrationNumber)
        {
            bool isInGarge = false;

            foreach (CustomerData customerData in m_CustomersDataList)
            {
                if (customerData.Vehicle.RegistrationNumber == i_RegistrationNumber)
                {
                    isInGarge = true;
                    customerData.VehicleStatus = eVehicleStatus.Repairing;
                    throw new ArgumentException("Vehicle already in the garage ,vehicle is in repair");
                }
            }

            return isInGarge;
        }

        public CustomerData FineCustomerData(string i_RegistrationNumber)
        {
            object customerWanted = new object();
            bool customerFound = false;

            foreach (CustomerData customer in m_CustomersDataList)
            {
                if (customer.Vehicle.RegistrationNumber == i_RegistrationNumber)
                {
                    customerWanted = customer;
                    customerFound = true;
                    break;
                }
            }

            if (!customerFound)
            {
                throw new ArgumentException("Vehicle is not found in the garage");
            }

            return customerWanted as CustomerData;
        }

        public Vehicle FindVehicleInGarage(string i_RegistrationNumber)
        {
            object vehicleWanted = new object();
            bool vehicleFound = false;

            foreach (Vehicle vehicle in m_VehiclesList)
            {
                if (i_RegistrationNumber == vehicle.RegistrationNumber)
                {
                    vehicleWanted = vehicle;
                    vehicleFound = true;
                    break;
                }
            }

            if (!vehicleFound)
            {
                throw new ArgumentException("Vehicle is not found in the garage");
            }

            return vehicleWanted as Vehicle;
        }

        public StringBuilder GetAllRegistrationNumbers()
        {
            StringBuilder sb = new StringBuilder();

            foreach (CustomerData customerData in m_CustomersDataList)
            {
                sb.AppendFormat("{0}{1}", customerData.Vehicle.RegistrationNumber, Environment.NewLine);
            }

            return sb;
        }

        public StringBuilder GetFilteredRegistrationNumbers(eVehicleStatus i_VehicleStatus)
        {
            StringBuilder sb = new StringBuilder();

            foreach (CustomerData customerData in m_CustomersDataList)
            {
                if (customerData.VehicleStatus == i_VehicleStatus)
                {
                    sb.AppendFormat("{0}{1}", customerData.Vehicle.RegistrationNumber, Environment.NewLine);
                }
            }

            return sb;
        }

        public void ChangeVehicleStatus(string i_RegistrationNumber, eVehicleStatus i_NewStatus)
        {
            foreach (CustomerData customerData in m_CustomersDataList)
            {
                if (customerData.Vehicle.RegistrationNumber == i_RegistrationNumber)
                {
                    customerData.VehicleStatus = i_NewStatus;
                    return;
                }
            }

            throw new ArgumentException("Vehicle not found in the garage");
        }

        public void FuelVehicle(string i_RegistrationNumber, eFuel i_FuelType, float i_LitersToAdd)
        {
            Vehicle vehicle = FindVehicleInGarage(i_RegistrationNumber);
            if (vehicle is FuelBasedVehicle)
            {
                if (vehicle is FuelBasedCar)
                {
                    if ((vehicle as FuelBasedCar).FuelType == i_FuelType)
                    {
                        (vehicle as FuelBasedCar).AddFuel(i_LitersToAdd);
                    }
                    else
                    {
                        throw new ArgumentException("The fuel type chosen doesn't match the vehicle fuel type");
                    }
                }
                else if (vehicle is FuelBasedMotorcycle)
                {
                    if ((vehicle as FuelBasedMotorcycle).FuelType == i_FuelType)
                    {
                        (vehicle as FuelBasedVehicle).AddFuel(i_LitersToAdd);
                    }
                    else
                    {
                        throw new ArgumentException("The fuel type chosen doesn't match the vehicle fuel type");
                    }
                }
                else if (vehicle is Truck)
                {
                    if ((vehicle as Truck).FuelType == i_FuelType)
                    {
                        (vehicle as FuelBasedVehicle).AddFuel(i_LitersToAdd);
                    }
                    else
                    {
                        throw new ArgumentException("The fuel type chosen doesn't match the vehicle fuel type");
                    }
                }
            }
            else
            {
                throw new ArgumentException("This vehicle is not fuel based.");
            }
        }

        public void InflateToMax(string i_RegistrationNumber)
        {
            Vehicle vehicle = FindVehicleInGarage(i_RegistrationNumber);

            foreach (Wheel wheel in vehicle.m_Wheels)
            {
                wheel.InflateToMaxPsi();
            }
        }

        public void ChargeBattery(string o_RegistrationNumber, float i_MinutesToCharge)
        {
            Vehicle vehicle = FindVehicleInGarage(o_RegistrationNumber);

            if (vehicle is ElectricVehicle)
            {
                (vehicle as ElectricVehicle).ChargeBattery(i_MinutesToCharge / 60);
            }
            else
            { 
                throw new ArgumentException("This vehicle is not electric");
            }
        }
    }
}
