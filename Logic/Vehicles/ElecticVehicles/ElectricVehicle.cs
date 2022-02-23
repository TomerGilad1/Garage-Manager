using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.Logic
{
    public class ElectricVehicle : Vehicle
    {
        private float m_RemainingBatteryTime;
        private float m_MaxBatteryTime;

        public void SetFields(string i_Model, string i_RegistrationNumber, float i_RemainingBatteryTime, float i_MaxBatteryTime)
        {
            float energyPercentage = (i_RemainingBatteryTime / i_MaxBatteryTime) * 100;

            if (i_RemainingBatteryTime > i_MaxBatteryTime)
            {
                throw new ValueOutOfRangeException(0, i_MaxBatteryTime, $"{i_RemainingBatteryTime} hours of battery time is more then maximum value of battery time: {i_MaxBatteryTime}");
            }

            if (i_RemainingBatteryTime <= 0f)
            {
                throw new ArgumentException("Remaining battery time must be a positive number.");
            }

            base.SetFields(i_Model, i_RegistrationNumber, energyPercentage);
            m_RemainingBatteryTime = i_RemainingBatteryTime;
            m_MaxBatteryTime = i_MaxBatteryTime;
        }

        public void ChargeBattery(float i_HoursToCharge)
        {
            float newBatteryTime = m_RemainingBatteryTime + i_HoursToCharge;

            if (newBatteryTime > m_MaxBatteryTime)
            {
                throw new ValueOutOfRangeException(0, m_MaxBatteryTime, $"Cannot add {i_HoursToCharge} hours of battery time,The current battery is {m_RemainingBatteryTime} hours and the maximum hours of the battery is {m_MaxBatteryTime}");
            }

            m_RemainingBatteryTime = newBatteryTime;
            EnergyPercentage = (newBatteryTime / m_MaxBatteryTime) * 100;
        }

        public override string ToString()
        {
            return string.Format("Remaining Battery Time:{0}{3}Max Battery Time:{1}{3}{2}", m_RemainingBatteryTime, m_MaxBatteryTime, base.ToString(), Environment.NewLine);
        }
    }
}
