using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sparky;

namespace SparkyMSTest
{
    [TestClass]
    public class CalculatorMSTests
    {
        [TestMethod]
        public void AddNumber_InputTwoInt_GetCorrectAddition()
        {
            //Arrange
            var calculator = new Calculator();
            //Act
            var result=calculator.AddNumbers(10, 20);
            //Assert
            Assert.AreEqual(30, result);
        }
    }
}
