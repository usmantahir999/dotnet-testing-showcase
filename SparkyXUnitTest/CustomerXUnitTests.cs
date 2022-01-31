using Sparky;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SparkyXUnitTest
{
    public class CustomerxUnitTests
    {
        private Customer customer;

        public CustomerxUnitTests()
        {
            //Arrange
            customer = new Customer();
        }

        [Fact]
        public void CombineName_InputFirstAndLastName_ReturnsFullName()
        {
            //Act
            var result = customer.GreetAndCombineNames("Ben", "Spark");
            Assert.Equal( "Hello Ben Spark", result);
        }

        [Fact]
        public void IsHelloExist_InputFirstAndLastName_ReturnsTrue()
        {
            //Act
            var result = customer.GreetAndCombineNames("Ben", "Spark");
            Assert.Contains( "Hello",result);
        }

        [Fact]
        public void IsGreetNull_InputNull_ReturnsNull()
        {
            //Act
            //Assert
            Assert.Null(customer.GreetMessage);
        }

        [Fact]
        public void IsGreetNotNull_InputFirstAndLastName_ReturnsNotNull()
        {
            //Act
            customer.GreetAndCombineNames("Ben", "Spark");
            //Assert
            Assert.NotNull(customer.GreetMessage);
        }

        [Fact]
        public void DiscountChecker_DefaultCustomer_ReturnsDiscountInRange()
        {
            //Act
            var result = customer.Discount;
            //Assert
            //Assert.multiple NOT used to run multiple assert statements in exception cases in XUNIT
           
                Assert.InRange(result, 10, 25);


        }

        [Fact]
        public void GreetChecker_EmptyFirstName_ThrowsException()
        {
            var exceptionDetails = Assert.Throws<ArgumentException>(() => customer.GreetAndCombineNames("", "Spark"));
            Assert.Equal("Empty first name", exceptionDetails.Message);

        }
    }
}
