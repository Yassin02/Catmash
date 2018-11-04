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
        /// <param name="FirstScore">Score of the winner</param>
        /// <param name="SecondScore">Score of the loser</param>
        /// <returns>The score difference to Add/take from the two players</returns>
        public static int CalculateScoreDifference(int FirstScore, int SecondScore)
        {
            int scoreDifference = (int)(KFACTOR * (1 - ExpectationToWin(FirstScore, SecondScore)));

            return scoreDifference;
        }
    }
}
