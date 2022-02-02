using Bongo.Models.ModelValidations;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bongo.Models.Tests
{
    [TestFixture]
    public class DateInFutureAttributeTests
    {
    
        [TestCase(100, ExpectedResult= true)]
        [TestCase(0, ExpectedResult= false)]
        [TestCase(-100, ExpectedResult= false)]
        public bool DateValidator_InputeExpextedDateRange_DateValidity(int addTime)
        {
            DateInFutureAttribute dateInFutureAttribute = new DateInFutureAttribute(()=>DateTime.Now);
            return dateInFutureAttribute.IsValid(DateTime.Now.AddSeconds(addTime));
        }

        [Test]
        public void DateValidator_otValidateDate_ReturnErrorMessage()
        {
            var result = new DateInFutureAttribute();
            Assert.AreEqual("Date must be in the future", result.ErrorMessage);
        }
    }
   
}
