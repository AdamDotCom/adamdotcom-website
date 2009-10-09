using System.Web.Mvc;

namespace AdamDotCom.Website.App.Controllers
{
    [HandleError]
    public class ResumeController : Controller
    {
        public ActionResult Index()
        {
            ViewData["Message"] = "Welcome to ASP.NET MVC!";

            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}