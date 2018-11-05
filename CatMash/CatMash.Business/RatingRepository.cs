using CatMash.Business.Context;
using CatMash.Business.Model;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CatMash.Business
{
    public class RatingRepository
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// Get the list of the cats
        /// </summary>
        /// <returns></returns>
        public static List<Cat> GetCats()
        {
            log.Info("In : GetCats");

            List<Cat> cats = new List<Cat>();
            using (RatingContext context = new RatingContext())
            {
                cats = context.Cats.ToList();
            }

            log.Info("Out : GetCats");

            return cats;
        }

        /// <summary>
        /// Update a cat by passing its Id and the new score
        /// </summary>
        /// <param name="id"></param>
        /// <param name="score"></param>
        public static void UpdateCat(string id, int score)
        {
            log.Info(String.Format("In : UpdateCat : id = {0} ; score = {1}", id, score));

            using (RatingContext context = new RatingContext())
            {
                var record = context.Cats.SingleOrDefault(c => c.Id == id);
                if (record != null)
                {
                    record.Score = score;
                    context.SaveChanges();
                }
            }

            log.Info("Out : UpdateCat");

        }

        /// <summary>
        /// Get a cat by passing its Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Cat GetCat(string id)
        {
            log.Info(String.Format("In : GetCat : id = {0}", id));

            Cat cat = new Cat();
            using (RatingContext context = new RatingContext())
            {
                cat = context.Cats.Where(c => c.Id == id).FirstOrDefault();
            }

            log.Info("Out : GetCat");

            return cat;
        }

        /// <summary>
        /// Get a list of the cats by a descending order based on the score
        /// </summary>
        /// <returns></returns>
        public static List<Cat> GetCatsByOrder()
        {
            log.Info("In : GetCatsByOrder");

            List<Cat> cats = new List<Cat>();
            using (RatingContext context = new RatingContext())
            {
                cats = context.Cats.OrderByDescending(c => c.Score).ToList();
            }

            log.Info("Out : GetCatsByOrder");

            return cats;
        }

    }
}
