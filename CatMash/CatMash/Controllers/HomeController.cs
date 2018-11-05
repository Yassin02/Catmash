using CatMash.Core.RatingSystem;
using CatMash.Services;
using log4net;
using System;
using System.Net;
using System.Web.Mvc;

namespace CatMash.Web.Controllers
{
    public class HomeController : Controller
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// Send the data of the cats in the database to the View
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            log.Info("In : Index");

            try
            {
                ViewBag.List = CatComparerService.CatsToCompare();
            }
            catch (Exception ex)
            {
                log.Error("Exception : Index : {0}", ex);
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, String.Format("Unable to Get CatsToCompare : {0}", ex.Message));
            }
            finally
            {
                log.Info("Out : Index");
            }

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
            log.Info(String.Format("In : UpdateScore : idWinner = {0} ; idLoser={1}", idWinner, idLoser));
            try
            {
                var winnerCat = CatComparerService.GetCat(idWinner);
                var loserCat = CatComparerService.GetCat(idLoser);

                var scoresDifferance = CalculateRating.CalculateScoreDifference(winnerCat.Score, loserCat.Score);

                winnerCat.Score += scoresDifferance;
                loserCat.Score -= scoresDifferance;

                CatComparerService.UpdateScoreOfCat(winnerCat);
                CatComparerService.UpdateScoreOfCat(loserCat);
            }
            catch (Exception ex)
            {
                log.Error("Exception : UpdateScore : {0}", ex);
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, String.Format("Unable to Update Score : {0}", ex.Message));
            }
            finally
            {
                log.Info("Out : UpdateScore");
            }

            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }

    }
}