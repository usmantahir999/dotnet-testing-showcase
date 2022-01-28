using Moq;
using NUnit.Framework;
using Sparky;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkyNUnitTest
{
    [TestFixture]
    class BankAccountNUnitTests
    {
        private BankAccount account;
        [SetUp]
        public void Setup()
        {
            //Not unit test, it is an intgration test, unit test only deal with single class : e.g::: bankAccount = new BankAccount(new LogBook());
            //bankAccount = new BankAccount(new LogBook());
            
        }

        //[Test]
        //public void BankDepositLogFakker_Add100_ReturnTrue()
        //{
        //    //in real project faker class can not be implemented, because it takes alot of time and too much dummy code
        //    BankAccount bankAccount = new BankAccount(new LogFakker());
        //    var result=bankAccount.Deposit(100);
        //    Assert.IsTrue(result);
        //    Assert.That(bankAccount.GetBalance(), Is.EqualTo(100));
        //}

        [Test]
        public void BankDeposit_Add100_ReturnTrue()
        {
            var logMoq = new Mock<ILogBook>();
            BankAccount bankAccount = new BankAccount(logMoq.Object);
            var result = bankAccount.Deposit(100);
            Assert.IsTrue(result);
            Assert.That(bankAccount.GetBalance(), Is.EqualTo(100));
        }

        [Test]
        [TestCase(200,100)]
        public void BankWithDraw_WithDrawl100With200Balance_ReturnsTrue(int balance, int withDrawlAmount)
        {
            var logMoq = new Mock<ILogBook>();
            logMoq.Setup(u => u.LogToDb(It.IsAny<string>())).Returns(true);
            logMoq.Setup(u => u.LogBalanceAfterWithDrawl(It.Is<int>(x=>x>0))).Returns(true);
            BankAccount bankAccount = new BankAccount(logMoq.Object);
            bankAccount.Deposit(balance);
            var result = bankAccount.WithDraw(withDrawlAmount);
            Assert.IsTrue(result);


        }
    }
}
