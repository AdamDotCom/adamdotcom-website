using System.Web.Mvc;

namespace AdamDotCom.Website.App.Controllers
{
    [HandleError]
    public class ServicesController : Controller
    {
        [OutputCache(Duration = 172800, VaryByParam = "None")]
        public ActionResult Index()
        {
            return View();
        }
    }
}