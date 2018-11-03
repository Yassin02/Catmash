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
        public static List<Tuple<Cat,Cat>> CatsToCompare()
        {
            var cats = RatingRepository.GetCats();
            var list = Generator.GenerateAllPossibilities<Cat>(cats).Randomize();

            return list;
        }
    }
}
