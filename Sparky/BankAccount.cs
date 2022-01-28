using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparky
{
    public class BankAccount
    {
        private ILogBook _logBook;
        public int Balance { get; set; }

        public BankAccount(ILogBook logBook)
        {
            _logBook = logBook;
            Balance = 0;
        }

        public bool Deposit(int amount)
        {
            _logBook.Message("Deposit invoked");
            Balance += amount;
            return true;
        }

        public bool WithDraw(int amount)
        {
            if (Balance >= amount)
            {
                Balance -= amount;
                return true;
            }
            return false;
        }

        public int GetBalance() => Balance;
    }
}
