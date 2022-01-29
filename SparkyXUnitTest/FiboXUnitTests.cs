//using NUnit.Framework;
//using Sparky;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace SparkyXUnitTest
//{
//    [TestFixture]
//    class FiboXUnitTests
//    {
//        private Fibo Fibo;
//        [SetUp]
//        public void Setup()
//        {
//            Fibo = new Fibo();
//        }

//        [Test]
//        public void CalcFibo_Input1_ReturnsFiboSeries()
//        {
//            var expectedList = new List<int>() { 0 };
//            Fibo.Range = 1;
//            var result = Fibo.Fibonacci();
//            Assert.That(result, Is.Not.Empty);
//            Assert.That(result, Is.Ordered);
//            Assert.That(result, Is.EquivalentTo(expectedList));
            
//        }

//        [Test]
//        public void CalcFibo_Input6_ReturnsFiboSeries()
//        {
//            var expectedList = new List<int>() { 1, 1, 2, 3, 5, 8 };
//            Fibo.Range = 6;
//            var result = Fibo.Fibonacci();
//            Assert.That(result, Does.Contain(3));
//            Assert.That(result.Count, Is.EqualTo(6));
//            Assert.That(result, Has.No.Member(4));
//            Assert.That(result, Is.EquivalentTo(expectedList));


//        }
//    }
//}
