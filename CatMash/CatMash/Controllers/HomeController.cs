using CatMash.Core.RatingSystem;
using CatMash.Services;
using System.Net;
using System.Web.Mvc;

namespace CatMash.Web.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// Send the data of the cats in the database to the View
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            ViewBag.List = CatComparerService.CatsToCompare();

            return View();
        }

        /// <summary>
        /// Receive the winner and the loser Ids. Calculate the score and update it in each of them
        /// </summary>
        /// <param name="idWinner"></param>
        /// <param name="idLoser"></param>
        /// <returns>HttpStatusCode Ok</returns>
        public ActionResult UpdateScore(string idWinner, string idLoser)
        {
            var winnerCat = CatComparerService.GetCat(idWinner);
            var loserCat = CatComparerService.GetCat(idLoser);

            var scoresDifferance = CalculateRating.CalculateScoreDifference(winnerCat.Score, loserCat.Score);

            winnerCat.Score += scoresDifferance;
            loserCat.Score -= scoresDifferance;

            CatComparerService.UpdateScoreOfCat(winnerCat);
            CatComparerService.UpdateScoreOfCat(loserCat);

            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }
    }
}