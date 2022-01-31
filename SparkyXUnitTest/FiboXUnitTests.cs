using Sparky;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SparkyXUnitTest
{
    public class FiboXUnitTests
    {
        private Fibo Fibo;
        public FiboXUnitTests()
        {
            Fibo = new Fibo();
        }

        [Fact]
        public void CalcFibo_Input1_ReturnsFiboSeries()
        {
            var expectedList = new List<int>() { 1 };
            Fibo.Range = 1;
            var result = Fibo.Fibonacci();
            Assert.NotEmpty(result);
            Assert.Equal(expectedList.OrderBy(u=>u),result);
            Assert.True(result.SequenceEqual(expectedList));

        }

        [Fact]
        public void CalcFibo_Input6_ReturnsFiboSeries()
        {
            var expectedList = new List<int>() { 1, 1, 2, 3, 5, 8 };
            Fibo.Range = 6;
            var result = Fibo.Fibonacci();
            Assert.Contains(3, result);
            Assert.Equal(6, result.Count);
            Assert.DoesNotContain(4, result);
            Assert.Equal(result, expectedList);


        }
    }
}
