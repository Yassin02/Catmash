using System;
using System.Collections.Generic;
using CatMash.Core.RatingSystem;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CatMash.Tests
{
    [TestClass]
    public class GeneratorTest
    {
        #region Mock Data
        private readonly List<int> paramValue = new List<int>
        {
            1,2,3
        };

        private readonly List<Tuple<int, int>> expected = new List<Tuple<int, int>>
        {
            Tuple.Create(2,1),
            Tuple.Create(3,2),
            Tuple.Create(3,1),
        }; 
        #endregion

        [TestMethod]
        public void Show_Pass_When_ExcpectedNumberOfPossibilities()
        {
            var result = Generator.GenerateAllPossibilities<int>(paramValue);

            /* Number of possibilities from a list of n elements = n * (n - 1 ) / 2*/
            var length = expected.Count;
            Assert.AreEqual(length * (length - 1) / 2, result.Count);
        }

        [TestMethod]
        public void Show_Pass_When_ExcpectedResultsReturned()
        {
            var result = Generator.GenerateAllPossibilities<int>(paramValue);

            CollectionAssert.AreEqual(expected, result);
        }
    }
}
