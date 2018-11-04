using CatMash.Business;
using CatMash.Business.Model;
using CatMash.Core.Extensions;
using CatMash.Core.RatingSystem;
using System;
using System.Collections.Generic;

namespace CatMash.Services
{
    public class CatComparerService
    {
        /// <summary>
        /// Randomized the list of possible matches so that we don't have the possibilities returned in the same order everytime
        /// </summary>
        /// <returns></returns>
        public static List<Tuple<Cat,Cat>> CatsToCompare()
        {
            var cats = RatingRepository.GetCats();

            //Randomized the list of the possible matches
            var list = Generator.GenerateAllPossibilities<Cat>(cats).Randomize();

            return list;
        }

        /// <summary>
        /// Get a cat by its Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Cat GetCat(string id)
        {
            return RatingRepository.GetCat(id);
        }

        /// <summary>
        /// Get the ranking of the cats in a descending order
        /// </summary>
        /// <returns></returns>
        public static List<Cat> GetCatsRanking()
        {
            return RatingRepository.GetCatsByOrder();
        }

        /// <summary>
        /// Update the score of a given cat
        /// </summary>
        /// <param name="cat"></param>
        public static void UpdateScoreOfCat(Cat cat)
        {
            RatingRepository.UpdateCat(cat.Id, cat.Score);
        }
    }
}
