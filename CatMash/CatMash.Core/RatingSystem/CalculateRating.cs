using System;
using System.Collections.Generic;

namespace CatMash.Core.RatingSystem
{
    public class CalculateRating
    {
        /// <summary>
        /// The K-Factor for Elo rating system
        /// </summary>
        private const int KFACTOR = 32;

        /// <summary>
        /// Calculate the excpectation of winning of first param passed
        /// </summary>
        /// <param name="FirstScore">Score of a first given</param>
        /// <param name="SecondScore">Score of a second given</param>
        /// <returns></returns>
        public static double ExpectationToWin(int FirstScore, int SecondScore)
        {
            return 1 / (1 + Math.Pow(10, (SecondScore - FirstScore) / 400.0));
        }

        /// <summary>
        /// Calculate the score using the elo rating system
        /// </summary>
        /// <param name="FirstScore"></param>
        /// <param name="SecondScore"></param>
        /// <param name="result"></param>
        /// <returns>List of the new scores</returns>
        public static List<int> Calculate(int FirstScore, int SecondScore, int result)
        {
            int performanceRating = (int)(KFACTOR * (result - ExpectationToWin(FirstScore, SecondScore)));

            FirstScore += performanceRating;
            SecondScore -= performanceRating;

            List<int> scoreList = new List<int>
            {
                FirstScore,
                SecondScore
            };

            return scoreList;
        }
    }
}
