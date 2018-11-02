using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatMash.Core.RatingSystem
{
    public class Generator
    {
        private static readonly Random random = new Random();

        /// <summary>
        /// Generate all the possible matches of two elements without repitition from a given list
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items"></param>
        /// <returns></returns>
        public static List<Tuple<T, T>> GenerateAllPossibilities<T>(List<T> items) where T : new()
        {
            List<Tuple<T, T>> possibilities = new List<Tuple<T, T>>();

            for (int i = 0; i < items.Count; i++)
            {
                for (int j = i - 1; j >= 0; j--)
                {
                    possibilities.Add(Tuple.Create(items[i], items[j]));
                }
            }
            return possibilities;
        }
    }
}
