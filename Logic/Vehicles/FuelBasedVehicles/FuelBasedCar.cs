using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.Logic
{
    public class FuelBasedCar : FuelBasedVehicle
    {
        private eColor m_Color;
        private int m_Doors;

        public void SetFields(string o_Model, string o_RegistrationNumber, float o_CurrentFuelAmount, float o_MaxFuelAmount, int i_Doors, eColor i_Color, List<Wheel> i_Wheels)
        {
            if (i_Doors > 5 || i_Doors < 2)
            {
                throw new ArgumentException("Car must have only 2-5 doors");
            }

            base.SetFields(o_Model, o_RegistrationNumber, o_CurrentFuelAmount, o_MaxFuelAmount, eFuel.Octane95);
            m_Color = i_Color;
            m_Doors = i_Doors;
            m_Wheels = i_Wheels;
        }

        public override string ToString()
        {
            return string.Format("{3}Car color: {0}{2}The car has: {1} Doors{2}", m_Color, m_Doors, Environment.NewLine, base.ToString());
        }
    }
}