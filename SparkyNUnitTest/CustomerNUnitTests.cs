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
        [Test]
        public void CombineName_InputFirstAndLastName_ReturnsFullName()
        {
            //Arrange
            var customer = new Customer();
            //Act
            var result = customer.GreetAndCombineNames("Ben","Spark");
            Assert.That(result, Is.EqualTo("Hello Ben Spark"));
        }

        [Test]
        public void IsHelloExist_InputFirstAndLastName_ReturnsTrue()
        {
            //Arrange
            var customer = new Customer();
            //Act
            var result = customer.GreetAndCombineNames("Ben", "Spark");
            Assert.That(result, Does.Contain("Hello"));
        }
    }
}
