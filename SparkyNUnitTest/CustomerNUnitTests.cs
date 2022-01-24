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
    public class CustomerNUnitTests
    {
        private Customer customer;
        [SetUp]
        public void Setup()
        {
            //Arrange
            customer = new Customer();
        }

        [Test]
        public void CombineName_InputFirstAndLastName_ReturnsFullName()
        {
            //Act
            var result = customer.GreetAndCombineNames("Ben","Spark");
            Assert.That(result, Is.EqualTo("Hello Ben Spark"));
        }

        [Test]
        public void IsHelloExist_InputFirstAndLastName_ReturnsTrue()
        {
            //Act
            var result = customer.GreetAndCombineNames("Ben", "Spark");
            Assert.That(result, Does.Contain("Hello"));
        }

        [Test]
        public void IsGreetNull_InputNull_ReturnsNull()
        {
            //Act
            //Assert
            Assert.IsNull(customer.GreetMessage);
        }

        [Test]
        public void IsGreetNotNull_InputFirstAndLastName_ReturnsNotNull()
        {
            //Act
            customer.GreetAndCombineNames("Ben", "Spark");
            //Assert
            Assert.IsNotNull(customer.GreetMessage);
        }

        [Test]
        public void DiscountChecker_DefaultCustomer_ReturnsDiscountInRange()
        {
            //Act
            var result=customer.Discount;
            //Assert
            //Assert.multiple used to run multiple assert statements in exception cases
            Assert.Multiple(() =>
            {
                Assert.That(result, Is.InRange(10, 25));
            });
           
        }

        [Test]
        public void GreetChecker_EmptyFirstName_ThrowsException()
        {
            var exceptionDetails=Assert.Throws<ArgumentException>(()=>customer.GreetAndCombineNames("", "Spark"));
            Assert.AreEqual("Empty first name", exceptionDetails.Message);

        }
    }
}
