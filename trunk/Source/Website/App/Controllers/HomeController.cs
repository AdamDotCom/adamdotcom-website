using System.Web.Mvc;

namespace AdamDotCom.Website.App.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        
        public ActionResult Index()
        {
            HttpContext.Response.Redirect("/journal/");
            return null;
        }
    }
}