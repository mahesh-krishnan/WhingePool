using System.Web.Mvc;

namespace WhingePool.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult WhingePools()
        {
            return View();
        }

        public ActionResult MyWhingePools()
        {
            return View();
        }
    }
}