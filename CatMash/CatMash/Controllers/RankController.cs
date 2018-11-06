using CatMash.Services;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace CatMash.Web.Controllers
{
    public class RankController : Controller
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// Send the ranking of the cats in an descending order based on the score
        /// </summary>
        /// <returns></returns>
        public ActionResult Rank()
        {
            log.Info("In : Rank");

            try
            {
                ViewBag.List = CatComparerService.GetCatsRanking();

            }
            catch (Exception ex)
            {
                log.Error("Exception : Rank : {0}", ex);
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, String.Format("Unable to Get Rank : {0}", ex.Message));
            }
            finally
            {
                log.Info("Out : Rank");
            }

            ViewBag.Title = "Rank";
            return View();
        }
    }
}