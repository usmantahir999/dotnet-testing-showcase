using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparky
{
    public interface ILogBook
    {
        void Message(string message);
        bool LogToDb(string message);
        bool LogBalanceAfterWithDrawl(int balanceAfterWithDrawl);
        string MessageWithReturnString(string message);
    }
    public class LogBook : ILogBook
    {
        public void Message(string message)
        {
            Console.WriteLine(message);
        }

        public bool LogToDb(string message)
        {
            Console.WriteLine(message);
            return true;
        }

        public bool LogBalanceAfterWithDrawl(int balanceAfterWithDrawl)
        {
            if (balanceAfterWithDrawl > 0)
            {
                Console.WriteLine("Success");
                return true;
            }
            Console.WriteLine("failure");
            return false;
        }

        public string MessageWithReturnString(string message)
        {
            Console.WriteLine(message);
            return message.ToLower();
        }
    }

    public class LogFakker //: ILogBook
    {
        public void Message(string message)
        {
            
        }
    }
}
