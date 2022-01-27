using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparky
{
    public class Fibo
    {
        public Fibo()
        {
            Range = 5;
        }
        public int Range { get; set; }
        public List<int> Fibonacci()
        {
            int a = 0;
            int b = 1;
            var list = new List<int>();

            for (int i = 0; i < Range; i++)
            {
                int temp = a;
                a = b;
                b = temp + b;
                list.Add(a);
            }
            return list;
        }
    }
}
