using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparky
{
    public class Customer
    {
        public string GreetMessage = null;
        public int Discount = 15;
        public string GreetAndCombineNames(string firstName, string lastName)
        {
            if (string.IsNullOrWhiteSpace(firstName))
                throw new ArgumentException("Empty first name");
            GreetMessage= $"Hello {firstName} {lastName}";
            Discount = 20;
            return GreetMessage;
        }
    }
}
