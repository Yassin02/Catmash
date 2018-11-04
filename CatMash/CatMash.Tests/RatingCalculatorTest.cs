using System;
using System.Collections.Generic;
using CatMash.Core.RatingSystem;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CatMash.Tests
{
    [TestClass]
    public class RatingCalculatorTest
    {
        [TestMethod]
        public void Should_Pass_When_ExcpectedResultsReturnedFor_ExpectationToWin()
        {
            //The two scores are the same, so it's 50/50 chance
            double result = CalculateRating.ExpectationToWin(100, 100);
            Assert.AreEqual(0.5, result);
        }

        [TestMethod]
        public void Should_Pass_When_ExcpectedResultsReturnedFor_Calculate()
        {
            // Same score entered, Score difference should be 16
            var expected = CalculateRating.CalculateScoreDifference(100, 100);
            Assert.AreEqual(expected, 16);
        }
    }
}
