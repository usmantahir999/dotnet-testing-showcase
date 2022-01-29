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
            _logBook.Message("Test");
            _logBook.LogSeverity = 101;
            var temp = _logBook.LogSeverity;
            Balance += amount;
            return true;
        }

        public bool WithDraw(int amount)
        {
            if (Balance >= amount)
            {
                _logBook.LogToDb("WithDrawl amount"+amount.ToString());
                Balance -= amount;
                return _logBook.LogBalanceAfterWithDrawl(Balance);
            }
            return _logBook.LogBalanceAfterWithDrawl(Balance-amount);
        }

        public int GetBalance() => Balance;
    }
}
