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
    class GradingCalculatorNUnitTests
    {
        private GradingCalculator gradingCalculator;
        [SetUp]
        public void Setup()
        {
            //Arrange
            gradingCalculator = new GradingCalculator();
        }

        [Test]
        public void GradeCalc_InputScore95Attendance90_GetGradeA()
        {
            gradingCalculator.Score = 95;
            gradingCalculator.AttendancePercentage = 90;
            string result = gradingCalculator.GetGrade();
            Assert.That(result, Is.EqualTo("A"));
        }

        [Test]
        public void GradeCalc_InputScore85Attendance90_GetGradeB()
        {
            gradingCalculator.Score = 85;
            gradingCalculator.AttendancePercentage = 90;
            string result = gradingCalculator.GetGrade();
            Assert.That(result, Is.EqualTo("B"));
        }

        [Test]
        public void GradeCalc_InputScore65Attendance90_GetGradeC()
        {
            gradingCalculator.Score = 65;
            gradingCalculator.AttendancePercentage = 90;
            string result = gradingCalculator.GetGrade();
            Assert.That(result, Is.EqualTo("C"));
        }

        [Test]
        public void GradeCalc_InputScore95Attendance65_GetGradeB()
        {
            gradingCalculator.Score = 95;
            gradingCalculator.AttendancePercentage = 65;
            string result = gradingCalculator.GetGrade();
            Assert.That(result, Is.EqualTo("B"));
        }

        [Test]
        [TestCase(95,55)]
        [TestCase(65,55)]
        [TestCase(50,90)]
        public void GradeCalc_FailureScenerios_GetGradeF(int score, int attendancePercentage)
        {
            gradingCalculator.Score = score;
            gradingCalculator.AttendancePercentage = attendancePercentage;
            string result = gradingCalculator.GetGrade();
            Assert.That(result, Is.EqualTo("F"));
        }

    }
}
