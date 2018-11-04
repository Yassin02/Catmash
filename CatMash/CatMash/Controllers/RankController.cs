using CatMash.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CatMash.Web.Controllers
{
    public class RankController : Controller
    {
        public ActionResult Rank()
        {
            ViewBag.List = CatComparerService.GetCatsRanking();

            return View();
        }
    }
}