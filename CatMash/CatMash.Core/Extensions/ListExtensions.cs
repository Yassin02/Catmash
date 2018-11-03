using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatMash.Core.Extensions
{
    public static class ListExtensions
    {
        private static readonly Random random = new Random();

        public static List<T> Randomize<T>(this List<T> list)
        {
            return list.OrderBy(x => random.Next()).Select(x => x).ToList();
        }
    }
}
