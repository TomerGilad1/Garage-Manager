using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;

namespace Ex03.Logic
{
    public class FuelBasedVehicle : Vehicle
    {
        private eFuel m_FuelType;
        private float m_CurrentFuel;
        private float m_MaxFuelAmount;

        public void SetFields(string i_Model, string i_RegistrationNumber, float i_CurrentFuel, float i_MaxFuelAmount, eFuel i_FuelType)
        {
            float energyPercentage = (i_CurrentFuel / i_MaxFuelAmount) * 100;

            if (i_CurrentFuel > i_MaxFuelAmount)
            {
                throw new ValueOutOfRangeException(0, i_MaxFuelAmount, "The Remaining fuel in liters cannot be higher than the maximum fuel amount");
            }

            if (i_CurrentFuel < 0f)
            {
                throw new ArgumentOutOfRangeException("The reaming fuel can be only positive number");
            }

            base.SetFields(i_Model, i_RegistrationNumber, energyPercentage);
            m_FuelType = i_FuelType;
            m_CurrentFuel = i_CurrentFuel;
            m_MaxFuelAmount = i_MaxFuelAmount;
        }

        public void AddFuel(float i_FuelToAdd)
        {
            float newFuel = m_CurrentFuel + i_FuelToAdd;

            if (newFuel > m_MaxFuelAmount)
            {
                throw new ValueOutOfRangeException(0, m_MaxFuelAmount, $"Cannot add {i_FuelToAdd} liters of fuel, the maximum fuel in this vehicle tank can have is {m_MaxFuelAmount}");
            }

            m_CurrentFuel = newFuel;
            EnergyPercentage = (newFuel / m_MaxFuelAmount) * 100;
        }

        public override string ToString()
        {
            return string.Format("Fuel Type:{0}{3}Current Fuel:{1}{3}Max Fuel:{2}{3}{4}", m_FuelType, m_CurrentFuel, m_MaxFuelAmount, Environment.NewLine, base.ToString());
        }

        public eFuel FuelType
        {
            get { return m_FuelType; }
            set { m_FuelType = value; }
        }
    }
}