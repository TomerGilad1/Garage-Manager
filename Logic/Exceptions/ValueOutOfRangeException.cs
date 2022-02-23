using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.Logic
{
    public class ValueOutOfRangeException : Exception
    {
        private readonly float m_MaxValue = 0;
        private readonly float m_MinValue = 0;

        public ValueOutOfRangeException(float i_MinValue, float i_MaxValue, string i_Message) : base(i_Message)
        {
            m_MinValue = i_MinValue;
            m_MaxValue = i_MaxValue;
        }

        public ValueOutOfRangeException(float i_MinValue, float i_MaxValue)
        {
            m_MinValue = i_MinValue;
            m_MaxValue = i_MaxValue;
        }

        public void PrintException()
        {
            Console.WriteLine($"Argument must be in range of {m_MinValue} to {m_MaxValue}");
        }
    }
}