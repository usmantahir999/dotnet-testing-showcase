﻿using Sparky;
using Xunit;

namespace SparkyXUnitTest
{
    public class GradingCalculatorXUnitTests
    {
        private GradingCalculator gradingCalculator;
        public GradingCalculatorXUnitTests()
        {
            //Arrange
            gradingCalculator = new GradingCalculator();
        }

        [Fact]
        public void GradeCalc_InputScore95Attendance90_GetGradeA()
        {
            gradingCalculator.Score = 95;
            gradingCalculator.AttendancePercentage = 90;
            string result = gradingCalculator.GetGrade();
            Assert.Equal("A", result);
        }

        [Fact]
        public void GradeCalc_InputScore85Attendance90_GetGradeB()
        {
            gradingCalculator.Score = 85;
            gradingCalculator.AttendancePercentage = 90;
            string result = gradingCalculator.GetGrade();
            Assert.Equal("B", result);
        }

        [Fact]
        public void GradeCalc_InputScore65Attendance90_GetGradeC()
        {
            gradingCalculator.Score = 65;
            gradingCalculator.AttendancePercentage = 90;
            string result = gradingCalculator.GetGrade();
            Assert.Equal("C",result);
        }

        [Fact]
        public void GradeCalc_InputScore95Attendance65_GetGradeB()
        {
            gradingCalculator.Score = 95;
            gradingCalculator.AttendancePercentage = 65;
            string result = gradingCalculator.GetGrade();
            Assert.Equal("B", result);
        }

        [Theory]
        [InlineData(95, 55)]
        [InlineData(65, 55)]
        [InlineData(50, 90)]
        public void GradeCalc_FailureScenerios_GetGradeF(int score, int attendancePercentage)
        {
            gradingCalculator.Score = score;
            gradingCalculator.AttendancePercentage = attendancePercentage;
            string result = gradingCalculator.GetGrade();
            Assert.Equal("F", result);
        }


        [Theory]
        [InlineData(95, 90,  "A")]
        [InlineData(85, 90, "B")]
        [InlineData(65, 90, "C")]
        [InlineData(95, 65, "B")]

        [InlineData(95, 55, "F")]
        [InlineData(65, 55, "F")]
        [InlineData(50, 90, "F")]
        public void GradeCalc_ExpectedScenerios_GetGrade(int score, int attendancePercentage, string expectedResult)
        {
            gradingCalculator.Score = score;
            gradingCalculator.AttendancePercentage = attendancePercentage;
            Assert.Equal( gradingCalculator.GetGrade(),expectedResult);

        }

    }
}
