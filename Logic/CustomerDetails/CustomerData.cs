using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.Logic
{
    public class CustomerData
    {
        private readonly string m_VehicleOwner;
        private readonly string m_OwnerPhoneNumber;
        private Vehicle m_Vehicle;
        private eVehicleStatus m_VehicleStatus;

        public CustomerData(string i_OwnerName, string i_OwnerPhone, Vehicle i_Vehicle)
        {
            object newVehicle = new object();

            m_VehicleOwner = i_OwnerName;
            m_OwnerPhoneNumber = i_OwnerPhone;
            m_Vehicle = i_Vehicle;
            m_VehicleStatus = eVehicleStatus.Repairing;
        }

        public Vehicle Vehicle
        {
            get { return m_Vehicle; }
            set { m_Vehicle = value; }
        }

        public eVehicleStatus VehicleStatus
        {
            get { return m_VehicleStatus; }
            set { m_VehicleStatus = value; }
        }

        public override string ToString()
        {
            return string.Format("Owner: {0}{2}Phone Number: {1}{2}{3}", m_VehicleOwner, m_OwnerPhoneNumber, Environment.NewLine, m_Vehicle.ToString());
        }
    }
}