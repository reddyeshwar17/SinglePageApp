using System.Web.Mvc;

namespace SinglePageWebApplication.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            //TempData.Add("Name","");
            return View();
        }

        public ActionResult SPA()
        {
            return View();
        }
    }
}