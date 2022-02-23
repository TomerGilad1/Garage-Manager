using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.Logic
{
    public abstract class Vehicle
    {
        private string m_Model;
        private string m_RegistrationNumber;
        private float m_EnergyPercentage;
        public List<Wheel> m_Wheels;

        public void SetFields(string i_Model, string i_RegistrationNumber)
        {
            m_Model = i_Model;
            m_RegistrationNumber = i_RegistrationNumber;
        }

        public void SetFields(string i_Model, string i_RegistrationNumber, float i_EnergyPercentage)
        {
            m_Model = i_Model;
            m_RegistrationNumber = i_RegistrationNumber;
            m_EnergyPercentage = i_EnergyPercentage;
        }

        public string RegistrationNumber
        {
            get { return m_RegistrationNumber; }
            set { m_RegistrationNumber = value; }
        }

        public float EnergyPercentage
        {
            get { return m_EnergyPercentage; }
            set { m_EnergyPercentage = value; }
        }

        public override string ToString()
        {
            int wheelNumber = 1;
            StringBuilder toString = new StringBuilder();
            toString.AppendFormat("Model:{0}{3}License number:{1}{3}Energy Percentage: {2}{3}", m_Model, m_RegistrationNumber, m_EnergyPercentage, Environment.NewLine);
            foreach (Wheel wheel in m_Wheels)
            {
                toString.AppendFormat("Wheel {0}.{2}{1}{2}", wheelNumber, wheel.ToString(), Environment.NewLine);
                wheelNumber++;
            }

            Console.Clear();
            Console.WriteLine(toString);
            return toString.ToString();
        }
    }
}
