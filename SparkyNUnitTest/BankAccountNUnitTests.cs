﻿using Moq;
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

        [Test]
        [TestCase(200, 300)]
        public void BankWithDraw_WithDrawl300With200Balance_ReturnsTrue(int balance, int withDrawlAmount)
        {
            var logMoq = new Mock<ILogBook>();
            logMoq.Setup(u => u.LogToDb(It.IsAny<string>())).Returns(true);
            logMoq.Setup(u => u.LogBalanceAfterWithDrawl(It.Is<int>(x => x > 0))).Returns(true);
            BankAccount bankAccount = new BankAccount(logMoq.Object);
            bankAccount.Deposit(balance);
            var result = bankAccount.WithDraw(withDrawlAmount);
            Assert.IsFalse(result);
        }

        [Test]
        public void BankLogDummy_LogMockString_ReturnsTrue()
        {
            var logMoq = new Mock<ILogBook>();
            var description = "hello";
            logMoq.Setup(u => u.MessageWithReturnString(It.IsAny<string>())).Returns((string str) => str.ToLower());
            Assert.That(logMoq.Object.MessageWithReturnString("Hello"),Is.EqualTo(description));
            
        }

        [Test]
        public void BankLogDummy_LogMockStringOutput_ReturnsTrue()
        {
            var logMoq = new Mock<ILogBook>();
            var output = "hello";
            logMoq.Setup(u => u.LogWithOutputResult(It.IsAny<string>(), out output)).Returns(true);
            string result = "";
            Assert.IsTrue(logMoq.Object.LogWithOutputResult("Ben", out result));
            Assert.That(result, Is.EqualTo(output));

        }

        [Test]
        public void BankLogRef_ReturnsTrue()
        {
            var logMoq = new Mock<ILogBook>();
            Customer customer = new();
            Customer customerNotUsed = new();

            logMoq.Setup(u => u.LogRefResult(ref customer)).Returns(true);
            Assert.IsFalse(logMoq.Object.LogRefResult(ref customerNotUsed));
            Assert.IsTrue(logMoq.Object.LogRefResult(ref customer));

        }

        [Test]
        public void BankLogSetAndGetProperites()
        {
            var logMoq = new Mock<ILogBook>();
            //Used to initiliaze properties
            logMoq.SetupAllProperties();
            logMoq.Setup(u => u.LogSeverity).Returns(10);
            logMoq.Setup(u => u.LogType).Returns("warning");
            logMoq.Object.LogSeverity = 100;
            Assert.That(logMoq.Object.LogSeverity, Is.EqualTo(100));
            Assert.That(logMoq.Object.LogType, Is.EqualTo("warning"));

            //callback
            string logTemp = "Hello, ";
            logMoq.Setup(u => u.LogToDb(It.IsAny<string>())).Returns(true).Callback((string str) => logTemp += str);
            logMoq.Object.LogToDb("Ben");
            Assert.That(logTemp, Is.EqualTo("Hello, Ben"));

            int counter = 5;
            logMoq.Setup(u => u.LogToDb(It.IsAny<string>())).Returns(true).Callback(() => counter++);
            logMoq.Object.LogToDb("Ben");
            logMoq.Object.LogToDb("Ben");
            Assert.That(counter, Is.EqualTo(7));

        }

        [Test]
        public void BankLog_VerifyExamples()
        {
            var logMoq = new Mock<ILogBook>();
            var bankAccount = new BankAccount(logMoq.Object);
            bankAccount.Deposit(100);
            Assert.That(bankAccount.GetBalance, Is.EqualTo(100));

            //verification
            logMoq.Verify(u => u.Message(It.IsAny<string>()), Times.Exactly(2));
            logMoq.Verify(u => u.Message("Test"), Times.AtLeastOnce);
            logMoq.VerifySet(u => u.LogSeverity = 101, Times.Once);
            logMoq.VerifyGet(u => u.LogSeverity, Times.Once);

        }
    }
}
