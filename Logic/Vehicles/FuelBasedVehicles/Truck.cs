using System;
using System.Collections.Generic;

namespace Ex03.Logic
{
    public class Truck : FuelBasedVehicle
    {
        private bool m_IsCarryingDangerousGoods;
        private float m_MaxCarryWeight;

        public void SetFields(string o_Model, string o_RegistrationNumber, float o_CurrentFuelAmount, float o_MaxFuelAmount, bool i_CarryingDangerousMaterials, float i_MaxCarryWeight, List<Wheel> i_Wheels)
        {
            if (i_MaxCarryWeight <= 0f)
            {
                throw new ArgumentException("Maximum carrying weight must be positive");
            }

            base.SetFields(o_Model, o_RegistrationNumber, o_CurrentFuelAmount, o_MaxFuelAmount, eFuel.Solar);
            m_IsCarryingDangerousGoods = i_CarryingDangerousMaterials;
            m_MaxCarryWeight = i_MaxCarryWeight;
            m_Wheels = i_Wheels;
        }

        public override string ToString()
        {
            Console.WriteLine("1");
            return string.Format("Contain dangerous toxic?{0}{2}Max carry weight:{1}kg{2}{3}", m_IsCarryingDangerousGoods, m_MaxCarryWeight, Environment.NewLine, base.ToString());
        }
    }
}