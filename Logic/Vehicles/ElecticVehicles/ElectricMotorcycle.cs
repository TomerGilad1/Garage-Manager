using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.Logic
{
    public class ElectricMotorcycle : ElectricVehicle
    {
        private int m_EngineVolume;
        private eMotorcycleLicenseType m_LicenseType;

        public void SetFields(string o_Model, string o_RegistrationNumber, float o_CurrentBatteryTime, float o_MaxBatteryTime, eMotorcycleLicenseType i_LicenseType, int i_EngineVolume, List<Wheel> i_Wheels)
        {
            if (i_EngineVolume < 1)
            {
                throw new ArgumentException("Engine volume must be higher than 0");
            }

            base.SetFields(o_Model, o_RegistrationNumber, o_CurrentBatteryTime, o_MaxBatteryTime);
            m_EngineVolume = i_EngineVolume;
            m_LicenseType = i_LicenseType;
            m_Wheels = i_Wheels;
        }

        public override string ToString()
        {
            return string.Format("Engine Volume:{0}{2}License Type:{1}{2}{3}", m_EngineVolume, m_LicenseType, Environment.NewLine, base.ToString());
        }
    }
}