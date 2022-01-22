using System;
using System.Collections.Generic;

namespace Sparky
{
    public class Calculator
    {
        public List<int> NumberRange = new List<int>();
        public int AddNumbers(int ist, int second)
        {
            return ist + second;
        }

        public bool IsOddNumber(int number)
        {
            return number % 2 != 0;
        }

        public bool IsEvenNumber(int number)
        {
            return number % 2 == 0;
        }

        public double AddDoubleNumbers(double ist, double second)
        {
            return ist + second;
        }

        public List<int> GetOddRange(int min, int max)
        {
            NumberRange.Clear();
            for (int i = min; i <= max; i++)
            {
                if(i%2 != 0)
                {
                    NumberRange.Add(i);
                }
            }
            return NumberRange;
        }
    }
}
