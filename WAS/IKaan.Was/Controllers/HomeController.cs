using System.Web.Mvc;

namespace IKaan.Was.Controllers
{
	public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
    }
}
