using System.Web.Mvc;
using AdamDotCom.Common.Website;
using AdamDotCom.Website.App.Services;

namespace AdamDotCom.Website.App.Controllers
{
    [HandleError]
    public class ResumeController : Controller
    {
        [OutputCache(Duration = 172800, VaryByParam = "None")]
        public ActionResult Index(string id)
        {
            ViewData.Add(new ResumeService().Find(id));

            return View();
        }
    }
}