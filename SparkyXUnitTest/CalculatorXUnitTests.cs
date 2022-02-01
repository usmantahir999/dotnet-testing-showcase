using Sparky;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SparkyXUnitTest
{
    public class CalculatorXUnitTests
    {
        [Fact]
        public void AddNumber_InputTwoInt_GetCorrectAddition()
        {
            //Arrange
            var calculator = new Calculator();
            //Act
            var result = calculator.AddNumbers(10, 20);
            //Assert
            Assert.Equal(30, result);
        }

        [Fact]
        public void IsOddChecker_InputOddInt_ReturnTrue()
        {
            //Arrange
            var calculator = new Calculator();
            //Act
            var result = calculator.IsOddNumber(5);
            //Assert
            //Assert classic model
            Assert.True(result);
            //Check object type
            //Assert.That(result, Is.TypeOf<bool>());
        }

        [Fact]
        public void IsOddChecker_InputOEvenInt_ReturnFalse()
        {
            //Arrange
            var calculator = new Calculator();
            //Act
            var result = calculator.IsOddNumber(10);
            //Assert
            //Assert constraint model
            //Assert.That(result, Is.EqualTo(false));
            Assert.False(result);
        }

        [Theory]
        [InlineData(2)]
        [InlineData(4)]
        [InlineData(6)]
        public void IsEvenChecker_InputOEvenInt_ReturnTrue(int number)
        {
            //Arrange
            var calculator = new Calculator();
            //Act
            var result = calculator.IsEvenNumber(number);
            //Assert constraint model
           // Assert.That(result, Is.EqualTo(true));
        }

        [Theory]
        [InlineData(2, true)]
        [InlineData(5, false)]
        public void IsEvenChecker_InputOEvenInt_ReturnTrueIfOdd(int number, bool expectedResult)
        {
            //Arrange
            var calculator = new Calculator();
            //Act and Assert
            var result= calculator.IsEvenNumber(number);
            Assert.Equal(expectedResult, result);

        }

        [Theory]
        [InlineData(5.4, 10.5)]//15.9
        [InlineData(5.43, 10.53)]//15.96
        [InlineData(5.49, 10.59)]//16.08
        public void AddNumber_InputTwoDouble_GetCorrectAddition(double ist, double second)
        {
            //Arrange
            var calculator = new Calculator();
            //Act
            var result = calculator.AddDoubleNumbers(ist, second);
            //Assert
            //Delta .2 means relative result
            Assert.Equal(15.9, result, 2);
        }

        [Fact]
        public void GetOddRange_InputMinMaxRange_ReturnValidOddNumberRange()
        {
            //Arrange
            var calculator = new Calculator();
            List<int> OddExpectedRange = new List<int>() { 5, 7, 9 };
            //Act
            List<int> expectedResult = calculator.GetOddRange(5, 10);
            //Assert
            Assert.Equal(expectedResult, OddExpectedRange);


        }



    }
}
