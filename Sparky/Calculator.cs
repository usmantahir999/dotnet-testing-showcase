using System;

namespace Sparky
{
    public class Calculator
    {
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
    }
}
