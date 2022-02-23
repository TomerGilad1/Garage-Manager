using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.Logic
{
    public class Wheel
    {
        private readonly string m_WheelManufacturer;
        private readonly float m_MaxPsi;
        private float m_CurrentPsi;

        public Wheel(string i_WheelManufacturer, float i_CurrentPsi, float i_MaxPsi)
        {
            if (i_CurrentPsi > i_MaxPsi)
            {
                throw new ValueOutOfRangeException(0, i_MaxPsi, "Wheel current Psi cannot be higher than max Psi");
            }

            if (i_CurrentPsi < 0f)
            {
                throw new ValueOutOfRangeException(0, i_MaxPsi, "Current Psi must be greater than zero");
            }

            m_WheelManufacturer = i_WheelManufacturer;
            m_CurrentPsi = i_CurrentPsi;
            m_MaxPsi = i_MaxPsi;
        }

        public void Inflate(float i_PsiToAdd)
        {
            float newPsi = i_PsiToAdd + CurrentPsi;

            if (newPsi > m_MaxPsi)
            {
                throw new ValueOutOfRangeException(0, m_MaxPsi, "Cannot increase Psi ,Wheel current Psi cannot be higher than max Psi");
            }
            else
            {
                m_CurrentPsi = newPsi;
            }
        }

        public void InflateToMaxPsi()
        {
            m_CurrentPsi = m_MaxPsi;
        }

        public float CurrentPsi
        {
            get { return m_CurrentPsi; }
            set { m_CurrentPsi = value; }
        }

        public override string ToString()
        {
            return string.Format("Wheel Manufacturer:{0} Current wheels Psi:{1}  Max wheels Psi:{2}", m_WheelManufacturer, m_CurrentPsi, m_MaxPsi);
        }
    }
}