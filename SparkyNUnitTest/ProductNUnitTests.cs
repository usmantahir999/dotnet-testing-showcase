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
    class ProductNUnitTests
    {
        [Test]
        public void GetPricePrice_PlatinumCustomer_ReturnsPrice20PercentDiscount()
        {
            Product product = new Product() { Price = 50 };
            var result=product.GetPrice(new Customer() { IsPlatium = true });
            Assert.That(result, Is.EqualTo(40));
        }
    }
}
