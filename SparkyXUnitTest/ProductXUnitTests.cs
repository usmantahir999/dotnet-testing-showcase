using Sparky;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SparkyXUnitTest
{
    
    public class ProductXUnitTests
    {
        [Fact]
        public void GetPricePrice_PlatinumCustomer_ReturnsPrice20PercentDiscount()
        {
            Product product = new Product() { Price = 50 };
            var result = product.GetPrice(new Customer() { IsPlatium = true });
            Assert.Equal(40,result);
        }
    }
}
