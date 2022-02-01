using Moq;
using Sparky;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SparkyXUnitTest
{
    public class BankAccountXUnitTests
    {
        private BankAccount account;
        public  BankAccountXUnitTests()
        {
            //Not unit test, it is an intgration test, unit test only deal with single class : e.g::: bankAccount = new BankAccount(new LogBook());
            //bankAccount = new BankAccount(new LogBook());

        }

        [Fact]
        public void BankDeposit_Add100_ReturnTrue()
        {
            var logMoq = new Mock<ILogBook>();
            BankAccount bankAccount = new BankAccount(logMoq.Object);
            var result = bankAccount.Deposit(100);
            Assert.True(result);
            Assert.Equal(100,bankAccount.GetBalance());
        }

        [Theory]
        [InlineData(200, 100)]
        public void BankWithDraw_WithDrawl100With200Balance_ReturnsTrue(int balance, int withDrawlAmount)
        {
            var logMoq = new Mock<ILogBook>();
            logMoq.Setup(u => u.LogToDb(It.IsAny<string>())).Returns(true);
            logMoq.Setup(u => u.LogBalanceAfterWithDrawl(It.Is<int>(x => x > 0))).Returns(true);
            BankAccount bankAccount = new BankAccount(logMoq.Object);
            bankAccount.Deposit(balance);
            var result = bankAccount.WithDraw(withDrawlAmount);
            Assert.True(result);
        }

        [Theory]
        [InlineData(200, 300)]
        public void BankWithDraw_WithDrawl300With200Balance_ReturnsTrue(int balance, int withDrawlAmount)
        {
            var logMoq = new Mock<ILogBook>();
            logMoq.Setup(u => u.LogToDb(It.IsAny<string>())).Returns(true);
            logMoq.Setup(u => u.LogBalanceAfterWithDrawl(It.Is<int>(x => x > 0))).Returns(true);
            BankAccount bankAccount = new BankAccount(logMoq.Object);
            bankAccount.Deposit(balance);
            var result = bankAccount.WithDraw(withDrawlAmount);
            Assert.False(result);
        }

        [Fact]
        public void BankLogDummy_LogMockString_ReturnsTrue()
        {
            var logMoq = new Mock<ILogBook>();
            var description = "hello";
            logMoq.Setup(u => u.MessageWithReturnString(It.IsAny<string>())).Returns((string str) => str.ToLower());
            Assert.Equal(logMoq.Object.MessageWithReturnString("Hello"), description);

        }

        [Fact]
        public void BankLogDummy_LogMockStringOutput_ReturnsTrue()
        {
            var logMoq = new Mock<ILogBook>();
            var output = "hello";
            logMoq.Setup(u => u.LogWithOutputResult(It.IsAny<string>(), out output)).Returns(true);
            string result = "";
            Assert.True(logMoq.Object.LogWithOutputResult("Ben", out result));
            Assert.Equal(result, output);

        }

        [Fact]
        public void BankLogRef_ReturnsTrue()
        {
            var logMoq = new Mock<ILogBook>();
            Customer customer = new();
            Customer customerNotUsed = new();

            logMoq.Setup(u => u.LogRefResult(ref customer)).Returns(true);
            Assert.False(logMoq.Object.LogRefResult(ref customerNotUsed));
            Assert.True(logMoq.Object.LogRefResult(ref customer));

        }

        [Fact]
        public void BankLogSetAndGetProperites()
        {
            var logMoq = new Mock<ILogBook>();
            //Used to initiliaze properties
            logMoq.SetupAllProperties();
            logMoq.Setup(u => u.LogSeverity).Returns(10);
            logMoq.Setup(u => u.LogType).Returns("warning");
            logMoq.Object.LogSeverity = 100;
            Assert.Equal(100,logMoq.Object.LogSeverity);
            Assert.Equal("warning",logMoq.Object.LogType);

            //callback
            string logTemp = "Hello, ";
            logMoq.Setup(u => u.LogToDb(It.IsAny<string>())).Returns(true).Callback((string str) => logTemp += str);
            logMoq.Object.LogToDb("Ben");
            Assert.Equal("Hello, Ben", logTemp);

            int counter = 5;
            logMoq.Setup(u => u.LogToDb(It.IsAny<string>())).Returns(true).Callback(() => counter++);
            logMoq.Object.LogToDb("Ben");
            logMoq.Object.LogToDb("Ben");
            Assert.Equal(7, counter);

        }

        [Fact]
        public void BankLog_VerifyExamples()
        {
            var logMoq = new Mock<ILogBook>();
            var bankAccount = new BankAccount(logMoq.Object);
            bankAccount.Deposit(100);
            Assert.Equal(100, bankAccount.GetBalance());

            //verification
            logMoq.Verify(u => u.Message(It.IsAny<string>()), Times.Exactly(2));
            logMoq.Verify(u => u.Message("Test"), Times.AtLeastOnce);
            logMoq.VerifySet(u => u.LogSeverity = 101, Times.Once);
            logMoq.VerifyGet(u => u.LogSeverity, Times.Once);

        }
    }
}
