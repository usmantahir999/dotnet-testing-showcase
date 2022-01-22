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
    public class CalculatorNUnitTests
    {
        [Test]
        public void AddNumber_InputTwoInt_GetCorrectAddition()
        {
            //Arrange
            var calculator = new Calculator();
            //Act
            var result = calculator.AddNumbers(10, 20);
            //Assert
            Assert.AreEqual(30, result);
        }

        [Test]
        public void IsOddChecker_InputOddInt_ReturnTrue()
        {
            //Arrange
            var calculator = new Calculator();
            //Act
            var result = calculator.IsOddNumber(5);
            //Assert
            //Assert classic model
            Assert.True(result);
        }

        [Test]
        public void IsOddChecker_InputOEvenInt_ReturnFalse()
        {
            //Arrange
            var calculator = new Calculator();
            //Act
            var result = calculator.IsOddNumber(10);
            //Assert
            //Assert constraint model
            Assert.That(result, Is.EqualTo(false));
        }

        [Test]
        [TestCase(2)]
        [TestCase(4)]
        [TestCase(6)]
        public void IsEvenChecker_InputOEvenInt_ReturnTrue(int number)
        {
            //Arrange
            var calculator = new Calculator();
            //Act
            var result = calculator.IsEvenNumber(number);
            //Assert constraint model
            Assert.That(result, Is.EqualTo(true));
        }

        [Test]
        [TestCase(2, ExpectedResult = true)]
        [TestCase(5, ExpectedResult = false)]
        public bool IsEvenChecker_InputOEvenInt_ReturnTrueIfOdd(int number)
        {
            //Arrange
            var calculator = new Calculator();
            //Act and Assert
            return calculator.IsEvenNumber(number);

        }

        [Test]
        [TestCase(5.4, 10.5)]//15.9
        [TestCase(5.43, 10.53)]//15.93
        [TestCase(5.49, 10.59)]//16.08
        public void AddNumber_InputTwoDouble_GetCorrectAddition(double ist, double second)
        {
            //Arrange
            var calculator = new Calculator();
            //Act
            var result = calculator.AddDoubleNumbers(ist, second);
            //Assert
            //Delta .2 means relative result
            Assert.AreEqual(15.9, result, .2);
        }

        [Test]
        public void GetOddRange_InputMinMaxRange_ReturnValidOddNumberRange()
        {
            //Arrange
            var calculator = new Calculator();
            List<int> OddExpectedRange = new List<int>() { 5, 7, 9 };
            //Act
            List<int> expectedResult = calculator.GetOddRange(5,10);
            //Assert
            Assert.That(expectedResult, Is.EquivalentTo(OddExpectedRange));

           
        }



    }
}
