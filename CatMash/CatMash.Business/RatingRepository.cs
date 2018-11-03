using CatMash.Business.Context;
using CatMash.Business.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CatMash.Business
{
    public class RatingRepository
    {
        public static List<Cat> GetCats()
        {
            List<Cat> cats = new List<Cat>();
            try
            {
                using (RatingContext context = new RatingContext())
                {
                    cats = context.Cats.ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return cats;
        }

        public static void Update(string id, int score)
        {
            try
            {
                using (RatingContext context = new RatingContext())
                {
                    var record = context.Cats.SingleOrDefault(c => c.Id == id);
                    if (record != null)
                    {
                        record.Score = score;
                        context.SaveChanges();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
