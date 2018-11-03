using CatMash.Services;
using System.Web.Mvc;

namespace CatMash.Web.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            ViewBag.List = CatComparerService.CatsToCompare();

            return View();
        }
    }
}